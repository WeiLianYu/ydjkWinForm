using SerialPortLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using 移动家客WinApp.Business.IService;
using 移动家客WinApp.Business.Service;
using 移动家客WinApp.Comm;
using 移动家客WinApp.Model.Input.Fx;
using 移动家客WinApp.Model.Output.System;
using 移动家客WinApp.SerialPortLib;

namespace 移动家客WinApp
{
    public partial class SealingBox : Form
    {
        private PrintDocument prtdoc = new PrintDocument();

        private int? sx_totalCount = 0;//总数据个数
        private int? sx_pageCount = 0;//总页数
        private int sx_currentPageIndex = 1;//当前页索引
        private IFxBoxService _FxBox;
        private IAreaService _Area;
        private string PrintName = string.Empty;

        public SealingBox(string userName)
        {
            InitializeComponent();

            _FxBox = new FxBoxService();
            _Area = new AreaService();

            this.lblUserName.Text = userName;
            AddColumn();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");

            ManagementScope scope = new ManagementScope(@"\root\cimv2");
            scope.Connect();

            string strDefaultPrinter1 = prtdoc.PrinterSettings.PrinterName;//获取默认的打印机名
            string strDefaultPrinter = "";

            foreach (string ss in PrinterSettings.InstalledPrinters)
            {
                ///在列表框中列出所有的打印机,
                this.comboBox1.Items.Add(ss);
                if (ss == strDefaultPrinter1)//把默认打印机设为缺省值
                {
                    comboBox1.SelectedIndex = comboBox1.Items.IndexOf(ss);
                    foreach (ManagementObject printer in searcher.Get())
                    {
                        strDefaultPrinter = printer["Name"].ToString().ToLower();
                        if (strDefaultPrinter.IndexOf(strDefaultPrinter1.ToLower()) > -1)
                        {
                            if (printer["WorkOffline"].ToString().ToLower().Equals("true"))
                            {
                                switch (MessageBox.Show("默认打印机未连接或出错", "警告", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error))
                                {
                                    case DialogResult.Retry:
                                        break;
                                }
                                // printer is offline by user
                            }
                            else
                            {
                                // printer is not offline
                            }
                        }
                    }
                }
                PrintName = comboBox1.Text;
            }

            DataGridViewBind();
        }

        private void AddColumn()
        {
            //为dgv增加一列按钮
            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.Name = "BtnScanCode";    //设置列的名称
            btn1.Text = "扫码";     //按钮上的文字属性
            btn1.DefaultCellStyle.NullValue = "扫码";
            btn1.HeaderText = "";     //显示的列名
            //btn1.Width = 50;
            this.gdvFX_Box.Columns.Insert(1, btn1); //在dataGridView1的最后一列添加按钮

            //为dgv增加一列按钮
            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            btn2.Name = "BtnPrint";    //设置列的名称
            btn2.Text = "打印";     //按钮上的文字属性
            btn2.DefaultCellStyle.NullValue = "打印";
            btn2.HeaderText = "操作";     //显示的列名
            //btn1.Width = 50;
            this.gdvFX_Box.Columns.Insert(1, btn2); //在dataGridView1的最后一列添加按钮

            ////为dgv增加一列复选框列
            //DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
            ////列显示名称
            //checkbox.HeaderText = "选择";
            //checkbox.Name = "IsChecked";
            //checkbox.TrueValue = true;
            //checkbox.FalseValue = false;
            //checkbox.DataPropertyName = "IsChecked";
            ////列宽
            ////checkbox.Width = 50;
            ////列大小不改变
            //checkbox.Resizable = DataGridViewTriState.False;
            ////添加的checkbox在dgv第一列
            //this.dataGridView1.Columns.Insert(1, checkbox);

            //再增加一列按钮
            //DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            //btn2.Name = "EndBtn";    //设置列的名称
            //btn2.Text = "停止";     //按钮上的文字属性
            //btn2.HeaderText = "操作2";     //显示的列名
            //this.dataGridView1.Columns.Insert(11, btn2);//在dataGridView2的指定列添加按钮
        }

        private async void DataGridViewBind()
        {
            ////行高自适应
            gdvFX_Box.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            ////标题不换行
            //dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            this.gdvFX_Box.AutoGenerateColumns = false;
            List<SealingBoxInfo_T> al = new List<SealingBoxInfo_T>();
            al.Add(new SealingBoxInfo_T { Id = 1, Column1 = "123456789123456", Column2 = "FZ000000001", Column3 = "武汉", Column4 = "12", Column5 = "SF-01", Column6 = "新建", Column7 = "管理员", Column8 = "管理员", Column9 = "2022-01-23" });
            al.Add(new SealingBoxInfo_T { Id = 2, Column1 = "223456789123456", Column2 = "FZ000000002", Column3 = "武汉", Column4 = "21", Column5 = "SF-02", Column6 = "新建", Column7 = "管理员", Column8 = "管理员", Column9 = "2022-02-24" });
            al.Add(new SealingBoxInfo_T { Id = 3, Column1 = "323456789123456", Column2 = "FZ000000003", Column3 = "武汉", Column4 = "33", Column5 = "SF-03", Column6 = "完成", Column7 = "管理员", Column8 = "管理员", Column9 = "2022-03-16" });

            var area2 = 0;
            if (cbxarea2.SelectedValue != null && !int.TryParse(cbxarea2.SelectedValue.ToString(), out area2))
            {
                MessageBox.Show($"请选择区县!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var nodel = new GetList_FxBoxDto
            {
                BatchNum = txtFX_Logistics_BatchNum.Text.Trim(),
                AreaId2 = area2
            };
            var query = await _FxBox.GetList(nodel);
            this.gdvFX_Box.DataSource = query.list;

            //一共多少条数据
            sx_totalCount = query.total;
            label12.Text = sx_totalCount.ToString();
            //页数
            var remainder = sx_totalCount % 10;
            if (remainder > 0)
            {
                sx_pageCount = ((sx_totalCount / 10) + 1);
                label10.Text = sx_pageCount.ToString();
            }
            else
            {
                sx_pageCount = (sx_totalCount / 10);
                label10.Text = sx_pageCount.ToString();
            }
            //当前页数
            textBox2.Text = sx_currentPageIndex.ToString();
        }

        public class SealingBoxInfo_T
        {
            public int Id { get; set; }
            public string Column1 { get; set; }
            public string Column2 { get; set; }
            public string Column3 { get; set; }
            public string Column4 { get; set; }
            public string Column5 { get; set; }
            public string Column6 { get; set; }
            public string Column7 { get; set; }
            public string Column8 { get; set; }
            public string Column9 { get; set; }
            public string Column10 { get; set; }
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //序号
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
               e.RowBounds.Location.Y,
               gdvFX_Box.RowHeadersWidth - 4,
               e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                gdvFX_Box.RowHeadersDefaultCellStyle.Font,
                rectangle,
                gdvFX_Box.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        /// <summary>
        ///扫码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //点击第一行button按钮事件
            if (gdvFX_Box.Columns[e.ColumnIndex].Name == "BtnScanCode")
            {
                string fxBoxId = gdvFX_Box.CurrentRow.Cells["Id"].Value.ToString();
                //MessageBox.Show(fxBoxId);
                ScanCode s = new ScanCode(this, fxBoxId, PrintName);
                s.ShowDialog();
            }
            else if (gdvFX_Box.Columns[e.ColumnIndex].Name == "BtnPrint")
            {
                //打印
                string batchnum = gdvFX_Box.CurrentRow.Cells["BatchNum"].Value.ToString();
                string Num = gdvFX_Box.CurrentRow.Cells["Num"].Value.ToString();
                string AreaName2 = gdvFX_Box.CurrentRow.Cells["AreaName2"].Value.ToString();
                string TerminalCount = gdvFX_Box.CurrentRow.Cells["TerminalCount"].Value.ToString();

                TSCPrint.TSCBoxsCode(AreaName2, Convert.ToInt32(TerminalCount), Num, batchnum, "TSC TTP-244 Pro");
                Thread.Sleep(50);
            }
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (gdvFX_Box.Rows.Count == 0 || gdvFX_Box.CurrentRow == null)
            {
                return;
            }
            string fxBoxId = gdvFX_Box.CurrentRow.Cells["Id"].Value.ToString();

            SealingBoxInfo sbselect = new SealingBoxInfo(this, fxBoxId);
            sbselect.ShowDialog();
        }

        /// <summary>
        /// 扫码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (gdvFX_Box.Rows.Count == 0 || gdvFX_Box.CurrentRow == null)
            {
                return;
            }
            string fxBoxId = gdvFX_Box.CurrentRow.Cells["Id"].Value.ToString();

            //MessageBox.Show(fxBoxId);
            //if (MessageBox.Show("ID:" + ID + " 确认扫码吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //}

            ////包装箱号
            //var FX_Box_Num = "111";
            ////批次号
            //var FX_Logistics_BatchNum = "222";
            ////厂家
            //var FX_Box_Manufactor = "333";
            ////终端类型
            ///
            //var FX_Box_TerminalType = "444";
            ////终端状态、分拣状态
            //var FX_Box_SortType = "555";
            ////终端型号
            //var FX_Box_TerminalModel = "666";
            ////地市
            //var FX_Box_areaid1 = "777";
            ////县市
            //var FX_Box_areaid2 = "888";
            //var FX_Box_TerminalCount = "1";

            ScanCode s = new ScanCode(this, fxBoxId, PrintName);
            s.ShowDialog();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (gdvFX_Box.Rows.Count == 0 || gdvFX_Box.CurrentRow == null)
            {
                return;
            }
            string ID = gdvFX_Box.CurrentRow.Cells["Id"].Value.ToString();
            if (MessageBox.Show("ID:" + ID + " 确认删除吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _FxBox.Del(ID);
                DataGridViewBind();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SealingBoxAdd sbadd = new SealingBoxAdd(this);
            if (sbadd.ShowDialog() == DialogResult.Cancel)
            {
                DataGridViewBind();
            }
        }

        private void butMore_Click(object sender, EventArgs e)
        {
            //var but = sender as Button;
            //if (but.Text == "更多")
            //{
            //    but.Text = "隐藏";
            //    panel1.Visible = true;
            //}
            //else
            //{
            //    but.Text = "更多";
            //    panel1.Visible = false;
            //}
        }

        private void SealingBox_Load(object sender, EventArgs e)
        {
            //this.butMore.Text = "更多";

            var portName = ConfigurationManagerHelpeor.ReadSetting("portName");
            cbxSerialPortList.Items.Add(portName);

            if (string.IsNullOrWhiteSpace(portName))
            {
                MessageBox.Show("没有获取到串口");
                SerialPortSetting sps = new SerialPortSetting();
                sps.ShowDialog(this);
            }
            else
            {
                cbxSerialPortList.SelectedIndex = 0;
            }
            BindArea();
        }

        /// <summary>
        /// 串口信息初始化
        /// </summary>
        private void SerialPortInfo()
        {
            string portName = string.Empty, baudRate = string.Empty, dataBit = string.Empty;
            int stopBit = 0, parity = 0;
            var SerialPort = ConfigurationManagerHelpeor.ReadAllSettings();
            if (SerialPort.ContainsKey("portName"))
            {
                portName = SerialPort["portName"];
            }
            if (SerialPort.ContainsKey("baudRate"))
            {
                baudRate = SerialPort["baudRate"];
            }
            if (SerialPort.ContainsKey("dataBit"))
            {
                dataBit = SerialPort["dataBit"];
            }
            if (SerialPort.ContainsKey("stopBit"))
            {
                stopBit = int.Parse(SerialPort["stopBit"]);
            }
            if (SerialPort.ContainsKey("parity"))
            {
                parity = int.Parse(SerialPort["parity"]);
            }
        }

        private async void BindArea()
        {
            var areaList = await _Area.GetList();
            cbxarea1.DataSource = areaList;
            cbxarea1.DisplayMember = "name";
            cbxarea1.ValueMember = "id";
            if (cbxarea1.Items.Count > 0)
            {
                cbxarea1.SelectedIndex = 0;
            }
        }

        private string[] LoadPortList()
        {
            try
            {
                return SerialPort.GetPortNames();
            }
            catch
            {
                return new string[] { };
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ScanCodeMatchSettings scms = new ScanCodeMatchSettings();
            scms.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SerialPortSetting sps = new SerialPortSetting();
            sps.ShowDialog(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //if (button5.Text.Trim() == "打开")
            //{
            //    var portName = cbxSerialPortList.Text;
            //    var baudRate = "9600";
            //    var dataBit = "8";
            //    var stopBit = 1;
            //    var parity = 0;

            //    if (serialPort.OpenSerialPort(portName, baudRate, dataBit, stopBit, parity, ReceiveData) == true)
            //    {
            //        button5.Text = "关闭";
            //    }
            //    else
            //    {
            //        MessageBox.Show("串口开发失败!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{
            //    if (serialPort.CloseSerialPort() == true)
            //    {
            //        button5.Text = "打开";
            //    }
            //}
        }

        private void SealingBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            if (sx_currentPageIndex == 1)
            {
                MessageBox.Show("已经是首页了");
            }
            else
            {
                sx_currentPageIndex = sx_currentPageIndex - 1;

                DataGridViewBind();
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            if (sx_currentPageIndex == sx_pageCount || sx_pageCount == 0)
            {
                MessageBox.Show("已经是最后一页了");
            }
            else
            {
                sx_currentPageIndex = sx_currentPageIndex + 1;

                DataGridViewBind();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataGridViewBind();
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
            var query = await _Area.GetList(id);
            query.Insert(0, new AreaDto { id = "0", name = "全部" });
            cbxarea2.DataSource = query;
            cbxarea2.DisplayMember = "name";
            cbxarea2.ValueMember = "id";
            if (cbxarea2.Items.Count > 0)
            {
                cbxarea2.SelectedIndex = 0;
            }
        }
    }
}