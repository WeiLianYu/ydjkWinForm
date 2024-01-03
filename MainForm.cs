using SerialPortLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using 移动家客WinApp.Business.IService;
using 移动家客WinApp.Business.Service;
using 移动家客WinApp.Comm;
using 移动家客WinApp.Model;
using 移动家客WinApp.Model.Input.Fx;
using 移动家客WinApp.Model.Input.QR;
using 移动家客WinApp.Model.Input.Terminal;
using 移动家客WinApp.Model.Output.Fx;
using 移动家客WinApp.Model.Output.QR;
using 移动家客WinApp.Model.Output.System;
using 移动家客WinApp.Model.Output.Terminal;
using 移动家客WinApp.SerialPortLib;

namespace 移动家客WinApp
{
    public partial class MainForm : Form
    {
        private PrintDocument prtdoc = new PrintDocument();
        private SerialPortHelper serialPort = null;

        private IFxBoxService _FxBox;
        private IAreaService _Area;
        private IDictionaryService _Dictionary;
        private IFxTerminalAccountService _FxTerminal;
        private IFxQRTemplateService QRSetting;
        private ITerminalModelService _TerminalModel;
        private IFxLogisticsService _fxLogistics;

        private IPrintBase Printer;
        private string PrintName = ConfigurationManagerHelpeor.ReadSetting("Printer");//"TSC";
        //public FxLogisticsDto Fx_Logistics;
        private FxBoxDto FX_Box;
        public TerminalModelInfo TerminalModel;

        private Form parentForm;

        public string portName;
        public int baudRate;
        public int dataBit;
        public int stopBit;
        public int parity;

        private static int LoadCount = 0;
        private int ScanCodeCount = 0;
        public static Dictionary<int, TerminalModelInfo> TerminalModels = new Dictionary<int, TerminalModelInfo>();
        private List<string> historySN = new List<string>();

        public static List<TerminalModelInfo> TerminalModelList = new List<TerminalModelInfo>();

        public MainForm(Form _parentForm)
        {
            InitializeComponent();


            serialPort = new SerialPortHelper();

            parentForm = _parentForm;

            _FxBox = new FxBoxService();
            _Area = new AreaService();
            _Dictionary = new DictionaryService();
            _FxTerminal = new FxTerminalAccountService();
            QRSetting = new FxQRTemplateService();
            _TerminalModel = new TerminalModelService();
            _fxLogistics = new FxLogisticsService();

            try
            {
                var model = new GetList_TerminalModelDto
                {
                    page = 1,
                    pagesize = 1000
                };

                TerminalModelList = _TerminalModel.GetList(model).Result.list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            };
        }

        private List<(string DeviceID, string PNPDeviceID, string Description)> GetUSBDevices()
        {
            List<(string DeviceID, string PNPDeviceID, string Description)> devices = new List<(string, string, string)>();

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
            {
                collection = searcher.Get();
            }

            List<(string, object)> s1list = new List<(string, object)>();
            foreach (var device in collection)
            {
                //foreach (var item in device.Properties)
                //{
                //    s1list.Add((item.Name, item.Value));
                //}

                devices.Add(((string)device.GetPropertyValue("DeviceID"),
                    (string)device.GetPropertyValue("PNPDeviceID"),
                    (string)device.GetPropertyValue("Description")));
            }

            collection.Dispose();
            return devices;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FX_Box = null;
            TerminalModel = null;
            this.QRCodeType = string.Empty;
            this.QRLength = 0;
            this.QRFirstCharacter = string.Empty;
            historySN.Clear();
            TerminalModels.Clear();

            LoadCount++;
            this.lblUserName.Text = Signin.UserInfo.realityname;

            portName = ConfigurationManagerHelpeor.ReadSetting("portName");
            int.TryParse(ConfigurationManagerHelpeor.ReadSetting("baudRate"), out baudRate);
            int.TryParse(ConfigurationManagerHelpeor.ReadSetting("dataBit"), out dataBit);
            int.TryParse(ConfigurationManagerHelpeor.ReadSetting("stopBit"), out stopBit);
            int.TryParse(ConfigurationManagerHelpeor.ReadSetting("parity"), out parity);
            txtSerialPort.Text = portName;

            BindPrinter();
            ControlInit();            

            //行高自适应
            gdvFX_Box.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            gdvFX_Box.AutoGenerateColumns = false;
            gdvFX_Box.Font = new Font("微软雅黑", 15);
            DataGridViewBind();

            ////行高自适应
            gdvFX_TerminalAccount.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            gdvFX_TerminalAccount.AutoGenerateColumns = false;
            gdvFX_TerminalAccount.Font = new Font("微软雅黑", 15);
            DataGridViewBindTerminal("-1");

            this.pnlbodyleft.Enabled = true;
            this.pnlbodyleft.BackColor = Color.YellowGreen;
            this.pnlbodyright.BackColor = Color.White;
            this.pnlbodyright.Enabled = false;

            if (LoadCount == 1)
            {

                BingArea();

                AddDataGridViewColumn();
                AddDataGridViewColumn2();

                timer1.Enabled = true;
                timer1.Interval = 1000;  //定时器时间间隔
                timer1.Start();   //定时器开始工作
            }

            //执行这个不能打印封装箱
            //GetgdvFXBoxCurrentRowData(FX_Box.Id, FX_Box.Num, FX_Box.TerminalCount);
        }

        private async void BingArea()
        {
            List<AreaDto> areaList = new List<AreaDto>();
            try
            {
                areaList = await _Area.GetList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            cbxarea1.DataSource = areaList;
            cbxarea1.DisplayMember = "name";
            cbxarea1.ValueMember = "id";
            if (cbxarea1.Items.Count > 0)
            {
                cbxarea1.SelectedIndex = 0;
            }
        }

        private async void cbxarea1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = string.Empty;
            var area = cbxarea1.SelectedValue as AreaDto;
            if (area != null)
            {
                id = area.id;
            }
            else
            {
                id = cbxarea1.SelectedValue as string;
            }
            List<AreaDto> query = new List<AreaDto>();
            try
            {
                query = await _Area.GetList(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cbxarea2.DataSource = query;
            cbxarea2.DisplayMember = "name";
            cbxarea2.ValueMember = "id";
            if (cbxarea2.Items.Count > 0)
            {
                cbxarea2.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 选择批次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFX_Logistics_date_Click(object sender, EventArgs e)
        {
            Select_Logistics log = new Select_Logistics();
            log.ShowDialog(this);
        }

        /// <summary>
        /// 开箱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnAddFX_Box_Click(object sender, EventArgs e)
        {
            var area1 = 0;
            if (cbxarea1.SelectedValue == null || !int.TryParse(cbxarea1.SelectedValue.ToString(), out area1))
            {
                MessageBox.Show($"请选择地市!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var area2 = 0;
            if (cbxarea2.SelectedValue == null || !int.TryParse(cbxarea2.SelectedValue.ToString(), out area2))
            {
                MessageBox.Show($"请选择区县!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var model = new Add_FxBoxDto
            {
                areaid1 = area1,
                areaid2 = area2,
                SortType = 1,
                TerminalCount = 0,
            };

            try
            {
                FX_Box = await _FxBox.Add(model);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewBind();

            GetgdvFXBoxCurrentRowData(FX_Box);
        }

        /// <summary>
        /// 绑定开箱列表
        /// </summary>
        private async void DataGridViewBind()
        {
            var model = new GetList_FxBoxDto
            {
                BatchNum = "",
                AreaId2 = 0,
                usertype = (int)Signin.UserInfo.usertype,
                pageindex = 1,
                pagesize = 500,
                createuserid = Signin.UserInfo.id
            };
            try
            {
                var query = await _FxBox.GetList(model);
                this.gdvFX_Box.DataSource = query.list;

                //FX_Box = query?.list?.Where(p => p.BoxStateName == "新建").OrderByDescending(p => p.createtime).FirstOrDefault();
                if (query?.list?.Any(p => p.BoxStateName == "新建") ?? false)
                {
                    btnAddFX_Box.Enabled = false;                 
                }
                else
                {
                    btnAddFX_Box.Enabled = true;
                }

                var allcount = query?.list?.Where(p => SqlMethods.DateDiffDay(p.createtime, DateTime.Now) == 0).Sum(p => (p?.TerminalCount ?? 0));
                lblDayStatistics.Text = allcount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        /// <summary>
        /// 检查默认串口
        /// </summary>
        private void CheckSerialPort()
        {
            try
            {
                if (!serialPort.IsOpen)
                {
                    if (!serialPort.OpenSerialPort(portName, baudRate, dataBit, stopBit, parity, ReceiveData))
                    {
                        MessageBox.Show("串口打开失败，无法使用扫描枪!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        SerialPortSetting sps = new SerialPortSetting();
                        sps.ShowDialog(this);

                        //MessageBox.Show($"设置完成后，需要窗体重新家登录才能生效", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //Application.Exit();
                        //this.OnLoad(null);
                    }
                    if (lblzdzt.Text.IndexOf("异常：端口") == 0)
                    {
                        lblzdzt.Text = "注意：使用数据识别不用设置型号，使用模式识别需设置型号！";
                    }
                }
            }
            catch (Exception ex)
            {
                serialPort = new SerialPortHelper();

                MessageBox.Show($"{ex.Message}", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SerialPortSetting sps = new SerialPortSetting();
                sps.ShowDialog(this);

                //MessageBox.Show($"设置完成后，需要程序登录才能生效", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //Application.Exit();
                //this.OnLoad(null);
            }
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        private async void ControlInit()
        {
            DictionaryDto Dictionarys = new DictionaryDto();
            //try
            //{
               
            //    Dictionarys = await _Dictionary.GetList("SortType");
            //    var SortTypeSource = Dictionarys.list;

            //    switch (ConfigurationManagerHelpeor.ReadSetting("TerminalState"))
            //    {
            //        case "报废":
            //            cbxTerminalState.SelectedIndex = 2;
            //            chkPrint.Checked = false;
            //            break;
            //        default:
            //            cbxTerminalState.SelectedIndex = 0;
            //            chkPrint.Checked = true;
            //            break;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            try
            {
                Dictionarys = await _Dictionary.GetList("Cleaner");
                var query = Dictionarys.list;
                query.Insert(0, new DictionaryInfo() { text = "--请选择--", value = 0 });
                cbxCleaner.DataSource = query;
                cbxCleaner.DisplayMember = "text";
                cbxCleaner.ValueMember = "value";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 添加操作列
        /// </summary>
        private void AddDataGridViewColumn()
        {
            //为dgv增加一列按钮
            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.Name = "BtnScanCode";    //设置列的名称
            btn1.Text = "分拣";     //按钮上的文字属性
            btn1.DefaultCellStyle.NullValue = "分拣";
            btn1.HeaderText = "";     //显示的列名
            //btn1.Width = 50;
            this.gdvFX_Box.Columns.Insert(0, btn1); //在dataGridView1的最后一列添加按钮
            this.gdvFX_Box.Columns[0].Width = 50;

            //为dgv增加一列按钮
            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            btn2.Name = "BtnPrint";    //设置列的名称
            btn2.Text = "打印";     //按钮上的文字属性
            btn2.DefaultCellStyle.NullValue = "打印";
            btn2.HeaderText = "操作";     //显示的列名
            //btn1.Width = 50;
            this.gdvFX_Box.Columns.Insert(0, btn2); //在dataGridView1的最后一列添加按钮
            this.gdvFX_Box.Columns[0].Width = 60;
        }

        /// <summary>
        /// 显示打印机列表
        /// </summary>
        private void BindPrinter()
        {
            if (string.IsNullOrWhiteSpace(PrintName))
            {
                MessageBox.Show($"缺少打印机!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (string p in PrinterSettings.InstalledPrinters)
            {
                if (p.ToUpper().Contains(PrintName.ToUpper()))//把默认打印机设为缺省值
                {
                    this.comboBox1.Items.Add(p);
                    comboBox1.SelectedIndex = 0;

                    //if (PrintName.ToUpper() == "TSC")
                    //{
                    //    Printer = new TSCPrint();
                    //    break;
                    //}
                    //else if (PrintName.ToUpper() == "ARGOX")
                    //{
                    //    var USBDevice = GetUSBDevices().Where(z => z.Description == "USB 打印支持").FirstOrDefault();
                    //    if (USBDevice.DeviceID != null)
                    //    {
                    //        Printer = new ArgonPPLB(string.Concat(@"\\?\", USBDevice.DeviceID.Replace(@"\", @"#"), "#", "{a5dcbf10-6530-11d2-901f-00c04fb951ed}"));
                    //        break;
                    //    }
                    //}
                }
            }

            if (this.comboBox1.Items.Count <= 0)
            {
                MessageBox.Show($"缺少打印机!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Printer = new TSCPrint();
            }
        }

        /// <summary>
        /// 分拣
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (gdvFX_Box.Rows.Count == 0 || gdvFX_Box.CurrentRow == null)
            {
                return;
            }
            string fxBoxId = gdvFX_Box.CurrentRow.Cells["Id"].Value.ToString();
            var Num = gdvFX_Box.CurrentRow.Cells["Num"].Value.ToString();
            var TerminalCount = gdvFX_Box.CurrentRow.Cells["TerminalCount"].Value.ToString();

            var BoxStateName = gdvFX_Box.CurrentRow.Cells["BoxStateName"].Value.ToString();
            if (BoxStateName == "新建")
            {
                var fxboxinfo = await _FxBox.Info(fxBoxId);
                GetgdvFXBoxCurrentRowData(fxboxinfo);
            }
            else
            {
                MessageBox.Show("封箱后不能分拣!");
            }
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gdvFX_Box.Rows.Count == 0 || gdvFX_Box.CurrentRow == null)
            {
                return;
            }
            string fxBoxId = gdvFX_Box.CurrentRow.Cells["Id"].Value.ToString();
            var BoxStateName = gdvFX_Box.CurrentRow.Cells["BoxStateName"].Value.ToString();

            var fxboxinfo = await _FxBox.Info(fxBoxId);
            this.txtNum.Text = fxboxinfo.Num;
            this.txtTerminalCount.Text = (fxboxinfo?.TerminalCount ?? 0).ToString();

            DataGridViewBindTerminal(fxBoxId);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (gdvFX_Box.Rows.Count == 0 || gdvFX_Box.CurrentRow == null)
            {
                return;
            }
            string ID = gdvFX_Box.CurrentRow.Cells["Id"].Value.ToString();
            string Num = gdvFX_Box.CurrentRow.Cells["Num"].Value.ToString();
            string BoxStateName = gdvFX_Box.CurrentRow.Cells["BoxStateName"].Value.ToString();
            if (BoxStateName == "封箱")
            {
                MessageBox.Show($"封箱数据不能删除!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("包装箱:" + Num + " 确认删除吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _FxBox.Del(ID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewBind();
            }
        }

        /// <summary>
        /// 窗口传值(日期，区县)
        /// </summary>
        /// <param name="values"></param>
        public void GetValue(Tuple<string, string> values)
        {
            //txtFX_Logistics_date.Text = values.Item1;
            //txtFX_Logistics_Area.Text = values.Item2;

            //btnAddFX_Box.Enabled = true;
            //btnAddFX_Box2.Enabled = true;
        }

        /// <summary>
        /// 窗口传值(串口列表)
        /// </summary>
        /// <param name="values"></param>
        public void UpdateSerialPort(string portName)
        {
            txtSerialPort.Text = portName;
        }

        /// <summary>
        /// 列表显示序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvFX_Box_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //序号
            //Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
            //   e.RowBounds.Location.Y,
            //   gdvFX_Box.RowHeadersWidth - 4,
            //   e.RowBounds.Height);
            //TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            //    gdvFX_Box.RowHeadersDefaultCellStyle.Font,
            //    rectangle,
            //    gdvFX_Box.RowHeadersDefaultCellStyle.ForeColor,
            //    TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        /// <summary>
        /// 触发列表点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void gdvFX_Box_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdvFX_Box.CurrentRow == null)
            {
                return;
            }
            //点击第一行button按钮事件
            if (gdvFX_Box.Columns[e.ColumnIndex].Name == "BtnScanCode")
            {
                 string fxBoxId = gdvFX_Box.CurrentRow.Cells["Id"].Value.ToString();
                var Num = gdvFX_Box.CurrentRow.Cells["Num"].Value.ToString();
                var TerminalCount = gdvFX_Box.CurrentRow.Cells["TerminalCount"].Value.ToString();

                var BoxStateName = gdvFX_Box.CurrentRow.Cells["BoxStateName"].Value.ToString();
                if (BoxStateName == "新建")
                {
                    var fxboxinfo = await _FxBox.Info(fxBoxId);
                    if (fxboxinfo == null)
                    {
                        MessageBox.Show("获取不到包装箱，不能打印!");
                        return;
                    }

                    GetgdvFXBoxCurrentRowData(fxboxinfo);
                }
                else
                {
                    MessageBox.Show("封箱后不能分拣!");
                }
            }
            else if (gdvFX_Box.Columns[e.ColumnIndex].Name == "BtnPrint")
            {
                //打印
                string Num = gdvFX_Box.CurrentRow.Cells["Num"].Value.ToString();
                string Id = gdvFX_Box.CurrentRow.Cells["Id"].Value.ToString();
                var BoxStateName = gdvFX_Box.CurrentRow.Cells["BoxStateName"].Value.ToString();

                if (BoxStateName == "封箱")
                {
                    BoxPrint(await _FxBox.Info(Id));
                }
                else
                {
                    MessageBox.Show("封箱前不能打印!");
                }
            }
        }

        /// <summary>
        /// 封箱打印
        /// </summary>
        private async void BoxPrint(FxBoxDto boxModel)
        {
            if (boxModel == null)
            {
                MessageBox.Show("缺少包装箱信息");
                return;
            }

            var model = new GetList_FxTerminalAccountDto
            {
                pageindex = 1,
                pagesize = 1000,
                boxId = boxModel.Id
            };

            //终端列表
            var Terminals = await _FxTerminal.GetList(model);
            if (Terminals?.list != null)
            {
                //按型号分组统计
                var ModelList = from a in Terminals.list
                                orderby a.Manufactor ascending
                                group a by new { a.ManufactorName, a.TerminalModelName } into g
                                select new ModelGroup
                                {
                                    ManufactorName = g.Key.ManufactorName,
                                    TerminalModelName = g.Key.TerminalModelName,
                                    Count = g.Count()
                                };

                float modellistcount = (float)ModelList.Count() / (float)5;
                decimal ternum = Math.Ceiling((decimal)modellistcount);
                int skip = 0;
                for (int i = 0; i < ternum; i++)
                {
                    if (i == 0)
                    {
                        Printer.BoxsPrint(i, boxModel.AreaName2, ModelList.Skip(skip).Take(5).ToList(), Terminals.list.Count(), boxModel.Num, this.lblUserName.Text, (DateTime)boxModel.CloseBoxtime, comboBox1.Text);
                        skip += 5;
                    }
                    else
                    {
                        Printer.BoxsPrint(i, boxModel.AreaName2, ModelList.Skip(skip).Take(7).ToList(), Terminals.list.Count(), boxModel.Num, this.lblUserName.Text, (DateTime)boxModel.CloseBoxtime, comboBox1.Text);
                        skip += 7;
                    }
                }
            }
        }

        /// <summary>
        /// 初始化终端数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Num"></param>
        /// <param name="TerminalCount"></param>
        private void GetgdvFXBoxCurrentRowData(FxBoxDto boxInfo)
        {
            FX_Box = boxInfo;
            if (FX_Box == null)
            {
                MessageBox.Show("缺少包装箱信息");
                return;
            }

            //扫码次数
            ScanCodeCount = 0;
            historySN.Clear();
            TerminalModels.Clear();

            this.txtNum.Text = boxInfo.Num;
            this.txtTerminalCount.Text = (boxInfo?.TerminalCount ?? 0).ToString();

            CheckSerialPort();

            if (serialPort.IsOpen)
            {
                DataGridViewBindTerminal(FX_Box.Id);

                this.pnlbodyleft.BackColor = Color.White;
                this.pnlbodyleft.Enabled = false;
                this.pnlbodyright.Enabled = true;
                this.pnlbodyright.BackColor = Color.YellowGreen;
            }
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 退出窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出程序吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
                //this.Close();
                //parentForm.Show()
            }
        }

        #region 终端

        /// <summary>
        /// 绑定终端列表
        /// </summary>
        /// <param name="num"></param>
        private async void DataGridViewBindTerminal(string Id)
        {
            var model = new GetList_FxTerminalAccountDto
            {
                pageindex = 1,
                pagesize = 1000,
                boxId = Id
            };

            try
            {
                var query = await _FxTerminal.GetList(model);
                this.gdvFX_TerminalAccount.DataSource = query.list;
            }
            catch (Exception ex)
            {
                StatusPrompt(ex);
                return;
            }
        }

        /// <summary>
        /// 显示列表序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdvFX_TerminalAccount_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //序号
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
               e.RowBounds.Location.Y,
               gdvFX_TerminalAccount.RowHeadersWidth - 4,
               e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                gdvFX_TerminalAccount.RowHeadersDefaultCellStyle.Font,
                rectangle,
                gdvFX_TerminalAccount.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        /// <summary>
        ///删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void gdvFX_TerminalAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdvFX_TerminalAccount.CurrentRow == null)
            {
                return;
            }
            //点击第一行button按钮事件
            if (gdvFX_TerminalAccount.Columns[e.ColumnIndex].Name == "BtnDel")
            {
                if (MessageBox.Show("确认删除吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string fxId = gdvFX_TerminalAccount.CurrentRow.Cells["Id2"].Value.ToString();
                    try
                    {
                        await _FxTerminal.Del(fxId);
                        txtTerminalCount.Text = (int.Parse(txtTerminalCount.Text) - 1).ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    historySN.Clear();
                    ScanCodeCount = 0;
                    DataGridViewBind();
                    DataGridViewBindTerminal(FX_Box.Id);
                }
            }
            else if (gdvFX_TerminalAccount.Columns[e.ColumnIndex].Name == "BtnPrint")
            {
                if (MessageBox.Show("确认补打吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string fxId = gdvFX_TerminalAccount.CurrentRow.Cells["Id2"].Value.ToString();
                    string CreateTime = gdvFX_TerminalAccount.CurrentRow.Cells["CreateTime"].Value.ToString();
                    var data = gdvFX_TerminalAccount.CurrentRow.Cells["SNNum"].Value.ToString();
                    int TerminalModel2;
                    int.TryParse(gdvFX_TerminalAccount.CurrentRow.Cells["TerminalModel2"].Value.ToString(), out TerminalModel2);
                    TerminalModel = await _TerminalModel.GetInfo(TerminalModel2);
                    try
                    {
                        if (!string.IsNullOrEmpty(data) && TerminalModel != null)
                        {
                            //TSCPrint.TSC(FX_Box.AreaName1 + FX_Box.AreaName2, this.lblUserName.Text, FX_Box.ManufactorName, FX_Box.TerminalModelName, FX_Box.TerminalTypeName, "1231", data, FX_Box.Num, comboBox1.Text);
                            Printer.TerminalPrint(FX_Box.AreaName1 + FX_Box.AreaName2, this.lblUserName.Text, TerminalModel.manufactorname, TerminalModel.model, "", TerminalModel.Adapter, data, FX_Box.Num, DateTime.Parse(CreateTime), comboBox1.Text);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    DataGridViewBind();
                    DataGridViewBindTerminal(FX_Box.Id);
                }
            }
        }

        /// <summary>
        /// 列表增加操作列
        /// </summary>
        private void AddDataGridViewColumn2()
        {
            //为dgv增加一列按钮
            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.Name = "BtnDel";    //设置列的名称
            btn1.Text = "删除";     //按钮上的文字属性
            btn1.DefaultCellStyle.NullValue = "删除";
            btn1.HeaderText = "";     //显示的列名
                                      //btn1.Width = 50;
            this.gdvFX_TerminalAccount.Columns.Insert(0, btn1); //在dataGridView1的最后一列添加按钮

            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            btn2.Name = "BtnPrint";    //设置列的名称
            btn2.Text = "补打";     //按钮上的文字属性
            btn2.DefaultCellStyle.NullValue = "补打";
            btn2.HeaderText = "操作";     //显示的列名
                                        //btn1.Width = 50;
            this.gdvFX_TerminalAccount.Columns.Insert(0, btn2); //在dataGridView1的最后一列添加按钮
                                                                ////为dgv增加一列按钮
                                                                //DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
                                                                //btn2.Name = "BtnPrint";    //设置列的名称
                                                                //btn2.Text = "打印";     //按钮上的文字属性
                                                                //btn2.DefaultCellStyle.NullValue = "打印";
                                                                //btn2.HeaderText = "操作";     //显示的列名
                                                                ////btn1.Width = 50;
                                                                //this.gdvFX_Box.Columns.Insert(1, btn2); //在dataGridView1的最后一列添加按钮
        }

        #endregion 终端

        #region 扫码枪

        //SN码匹配规则
        private string QRCodeType = "";

        private int QRLength = 0;
        private string QRFirstCharacter = "";

        //监听扫码枪数据
        private async void ReceiveData(object sender, SerialDataReceivedEventArgs e)
        {
            if (FX_Box == null)
            {
                StatusPrompt(alertMessage: "缺少包装箱信息，无法分拣！");
                return;
            }

            //报废不需要填写清洗人
            var Cleaner = string.Empty;
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    //lblzdzt.Text = $"扫码枪读取数据：{data}";
                    Cleaner = cbxCleaner.Text.Trim();
                }));
            }
            if (FX_Box.SortType != 3 && (string.IsNullOrWhiteSpace(Cleaner) || Cleaner == "--请选择--"))
            {
                StatusPrompt(alertMessage: "缺少清洗人，无法分拣！");
                return;
            }

            var ReceiveData = serialPort.GetRawReceiveData();
            Loger.WriteLog($"{"data"}:{ReceiveData}");
            var datas = ReceiveData.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            datas = datas.Where(p => !p.Contains("http") && !p.Contains("：") && !p.Contains(":") && !p.Contains("=")).ToArray();
            if (!datas.Any())
            {
                StatusPrompt(errorMessage: $"{ReceiveData.TrimEnd("\r\n".ToCharArray())},SN码格式不对");
                return;
            }
            datas = datas.Where(p => !historySN.Contains(p)).ToArray();
            if (!datas.Any())
            {
                StatusPrompt(errorMessage: $"{ReceiveData.TrimEnd("\r\n".ToCharArray())},SN码已存在");
                return;
            }
            foreach (var data in datas)
            {
                ScanCodeCount++;

                //Loger.WriteLog($"{"data"}:{data}");
                if (string.IsNullOrWhiteSpace(data))
                {
                    return;
                }
                else
                {
                    try
                    {
                        await Save(data, Cleaner);
                    }
                    catch (Exception ex)
                    {
                        StatusPrompt(ex);
                        return;
                    }
                }
            }

            async Task Save(string data, string Cleaner2)
            {
                var model = new SealingBoxDto
                {
                    snnum = data,
                    FX_BoxID = FX_Box.Id,
                    Cleaner = Cleaner2
                };
                var modelid = 0;
                try
                {
                    modelid = await _FxTerminal.SealingBox(model);

                    historySN.Add(data);
                    ScanCodeCount = 0;
                }
                catch (Exception ex)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            lblzdzt.Text = $"SN：{data}";
                        }));
                    }
                    MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        lblzdzt.Text = "提示：请开始扫码!";
                        txtTerminalCount.Text = (int.Parse(txtTerminalCount.Text.Trim()) + 1).ToString();
                        DataGridViewBind();
                        DataGridViewBindTerminal(FX_Box.Id);
                    }));
                }

                //try
                //{
                //    if (this.InvokeRequired)
                //    {
                //        this.Invoke(new Action(() =>
                //        {
                //            if (chkPrint.Checked)
                //            {
                //                var TModel = _TerminalModel.GetInfo(modelid).Result;
                //                if (TModel != null)
                //                {
                //                    Printer.TerminalPrint(FX_Box.AreaName1 + FX_Box.AreaName2, this.lblUserName.Text, TModel.manufactorname, TModel.model, "", TModel.Adapter, data, FX_Box.Num, DateTime.Now, comboBox1.Text);
                //                }
                //            }
                //        }));
                //    }

                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
            }
        }

        private async void QRRuleSet()
        {
            if (TerminalModel == null)
            {
                StatusPrompt(alertMessage: "缺少型号信息，无法进行SN码规则匹配");
                return;
            }
            var model = new GetInfo_QRDto
            {
                modelid = TerminalModel.Id //FX_Box.TerminalModelName
            };

            QRTemplateDto query = null;
            try
            {
                query = await QRSetting.GetQRInfo(model);
            }
            catch (Exception ex)
            {
                StatusPrompt(ex);
                return;
            }
            if (query == null)
            {
                StatusPrompt(alertMessage: "没有匹配上SN码规则");
                return;
            }

            this.QRCodeType = query.list?.FirstOrDefault()?.QRCodeType;
            this.QRLength = query.list?.FirstOrDefault()?.Length ?? 0;
            this.QRFirstCharacter = query.list?.FirstOrDefault()?.FirstCharacter;
            if (string.IsNullOrWhiteSpace(this.QRCodeType))
            {
                StatusPrompt(alertMessage: "SN码匹配规则信息不完整：条码？二维码？");
                return;
            }
            if (this.QRLength <= 0 && string.IsNullOrWhiteSpace(this.QRFirstCharacter))
            {
                StatusPrompt(alertMessage: "SN码匹配规则信息不完整：SN码长度？SN码起止字符？");
                return;
            }

            //if (QRCodeType == "条形码")
            //{
            //    BarCode();
            //}
            //else
            //{
            //    QRCode();
            //}
        }

        private void cbxSerialPortList_Click(object sender, EventArgs e)
        {
            SerialPortSetting ss = new SerialPortSetting();
            ss.ShowDialog(this);
        }

        /// <summary>
        /// 启用扫描二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QRCode()
        {
            List<byte[]> codeList = new List<byte[]>();
            codeList.Add(SNet_Code.NSet_Code_SETUPE1);
            codeList.Add(SNet_Code.NSet_Code_ALLENA0);
            codeList.Add(SNet_Code.NSet_Code_ALL2DC1);
            codeList.Add(SNet_Code.NSet_Code_SETUPE0);
            Command("启用扫描二维码", codeList);
        }

        /// <summary>
        /// 启用扫描条形码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarCode()
        {
            List<byte[]> codeList = new List<byte[]>();
            codeList.Add(SNet_Code.NSet_Code_SETUPE1);
            codeList.Add(SNet_Code.NSet_Code_ALLENA0);
            codeList.Add(SNet_Code.NSet_Code_ALL1DC1);
            codeList.Add(SNet_Code.NSet_Code_SETUPE0);
            Command("启用扫描条形码", codeList);
        }

        private void Command(string str, List<byte[]> codeList)
        {
            var result = false;
            try
            {
                foreach (var item in codeList)
                {
                    result = serialPort.Sendbyte(item);
                    Thread.Sleep(300);
                    if (!result)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                StatusPrompt(ex);
            }
        }

        #endregion 扫码枪

        /// <summary>
        /// 打开串口设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSerialPort_Click(object sender, EventArgs e)
        {
            SerialPortSetting sps = new SerialPortSetting();
            sps.ShowDialog(this);
        }

        /// <summary>
        /// 定时检查串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                CheckSerialPort();
            }
            catch (Exception ex)
            {
                StatusPrompt(ex);
            }
            finally
            {
                timer1.Start();
            }
        }

        /// <summary>
        /// 封箱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button5_Click(object sender, EventArgs e)
        {
            try
            {
                await _FxBox.ColseBox(FX_Box.Id);
                if (chkPrint.Checked)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        BoxPrint(await _FxBox.Info(FX_Box.Id));
                    }
                }
            }
            catch (Exception ex)
            {
                StatusPrompt(ex);
                return;
            }

            FX_Box = null;
            TerminalModel = null;
            this.QRCodeType = string.Empty;
            this.QRLength = 0;
            this.QRFirstCharacter = string.Empty;
            historySN.Clear();
            TerminalModels.Clear();

            //if (string.IsNullOrWhiteSpace(Fx_Logistics?.Id))
            //{
            //    Fx_Logistics = null;
            //    txtFX_Logistics_date.Text = "";
            //    txtFX_Logistics_Area.Text = "";
            //}

            this.lblzdzt.Text = "提示：请开始扫码！";
            this.pnlbodyleft.Enabled = true;
            this.pnlbodyleft.BackColor = Color.YellowGreen;
            this.pnlbodyright.BackColor = Color.White;
            this.pnlbodyright.Enabled = false;

            DataGridViewBind();
            //GetgdvFXBoxCurrentRowData("-1", "", null);
        }

        /// <summary>
        /// 扫码提示
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="alertMessage"></param>
        /// <param name="errorMessage"></param>
        private void StatusPrompt(Exception ex = null, string alertMessage = "", string errorMessage = "")
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    if (ex != null)
                    {
                        lblzdzt.Text = $"异常：{ex.Message}";
                    }
                    else if (!string.IsNullOrWhiteSpace(alertMessage))
                    {
                        lblzdzt.Text = $"警告：{alertMessage}";
                    }
                    else if (!string.IsNullOrWhiteSpace(errorMessage))
                    {
                        lblzdzt.Text = $"错误：{errorMessage}";
                    }
                }));
            }
            else
            {
                if (ex != null)
                {
                    lblzdzt.Text = $"异常：{ex.Message}";
                }
                else if (!string.IsNullOrWhiteSpace(alertMessage))
                {
                    lblzdzt.Text = $"警告：{alertMessage}";
                }
                else if (!string.IsNullOrWhiteSpace(errorMessage))
                {
                    lblzdzt.Text = $"错误：{errorMessage}";
                }
            }
        }

        private async void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string fxId = gdvFX_TerminalAccount.CurrentRow.Cells["Id2"].Value.ToString();
                try
                {
                    await _FxTerminal.Del(fxId);

                    txtTerminalCount.Text = (int.Parse(txtTerminalCount.Text) - 1).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataGridViewBind();
                DataGridViewBindTerminal(FX_Box.Id);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ScrapRecord sr = new ScrapRecord(this);
            sr.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要返回到开箱窗口吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.MainForm_Load(null, null);
            }
        }

        private async void 撤回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gdvFX_Box.Rows.Count == 0 || gdvFX_Box.CurrentRow == null)
            {
                return;
            }
            string ID = gdvFX_Box.CurrentRow.Cells["Id"].Value.ToString();
            string Num = gdvFX_Box.CurrentRow.Cells["Num"].Value.ToString();
            string BoxStateName = gdvFX_Box.CurrentRow.Cells["BoxStateName"].Value.ToString();

            if (BoxStateName == "封箱" && this.gdvFX_Box.CurrentRow.Index <= 1)
            {
                if (MessageBox.Show("包装箱:" + Num + " 确认解封吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        var model = new EidtBoxStateDto
                        {
                            id = ID,
                            boxstate = 1
                        };
                        await _FxBox.EidtBoxState(model);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DataGridViewBind();
                }
            }
            else
            {
                MessageBox.Show("最近一次封箱才能解封!");
            }
        }
    }
}