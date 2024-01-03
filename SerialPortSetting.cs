using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SerialPortLib;
using 移动家客WinApp.Comm;
using 移动家客WinApp.Model.Output.System;

namespace 移动家客WinApp
{
    public partial class SerialPortSetting : Form
    {
        public SerialPortHelper serialPort = new SerialPortHelper();
        private string globalData = "";

        private string portName;
        private int baudRate;
        private int dataBit;
        private int stopBit;
        private int parity;

        //开启设置
        private readonly byte[] NSet_Code_SETUPE1 = new byte[] { 0x7E, 0x01, 0x30, 0x30, 0x30, 0x30, 0x23, 0x53, 0x45, 0x54, 0x55, 0x50, 0x45, 0x31, 0x3B, 0x03 };
        //退出设置
        private readonly byte[] NSet_Code_SETUPE0 = new byte[] { 0x7E, 0x01, 0x30, 0x30, 0x30, 0x30, 0x23, 0x53, 0x45, 0x54, 0x55, 0x50, 0x45, 0x30, 0x3B, 0x03 };
        //开启扫码成功提示音
        private readonly byte[] NSet_Code_GRBENA1 = new byte[] { 0x7E, 0x01, 0x30, 0x30, 0x30, 0x30, 0x40, 0x47, 0x52, 0x42, 0x45, 0x4E, 0x41, 0x31, 0x3B, 0x03 };
        //关闭扫码成功提示音
        private readonly byte[] NSet_Code_GRBENA0 = new byte[] { 0x7E, 0x01, 0x30, 0x30, 0x30, 0x30, 0x40, 0x47, 0x52, 0x42, 0x45, 0x4E, 0x41, 0x30, 0x3B, 0x03 };
        //启用二维码扫描
        private readonly byte[] NSet_Code_ALL2DC1 = new byte[] { 0x7E, 0x01, 0x30, 0x30, 0x30, 0x30, 0x40, 0x41, 0x4C, 0x4C, 0x32, 0x44, 0x43, 0x31, 0x3B, 0x03 };
        //启用一维码扫描
        private readonly byte[] NSet_Code_ALL1DC1 = new byte[] { 0x7E, 0x01, 0x30, 0x30, 0x30, 0x30, 0x40, 0x41, 0x4C, 0x4C, 0x31, 0x44, 0x43, 0x31, 0x3B, 0x03 };
        //禁止所有条码
        private readonly byte[] NSet_Code_ALLENA0 = new byte[] { 0x7E, 0x01, 0x30, 0x30, 0x30, 0x30, 0x40, 0x41, 0x4C, 0x4C, 0x45, 0x4E, 0x41, 0x30, 0x3B, 0x03 };
        //感应模式
        private readonly byte[] NSet_Code_SCNMOD2 = new byte[] { 0x7E, 0x01, 0x30, 0x30, 0x30, 0x30, 0x40, 0x53, 0x43, 0x4E, 0x4D, 0x4F, 0x44, 0x32, 0x3B, 0x03 };
        //感应灵敏度
        private readonly byte[] NSet_Code_SENLVL8 = new byte[] { 0x7E, 0x01, 0x30, 0x30, 0x30, 0x30, 0x40, 0x53, 0x45, 0x4E, 0x4C, 0x56, 0x4C, 0x38, 0x3B, 0x03 };

        private string[] portList = null;

        public SerialPortSetting()
        {
            InitializeComponent();

            InitData();
        }

        private void InitData()
        {
            portList = LoadPortList();
            cbxSerialPortList.Items.AddRange(portList);

            if (portList.Length > 0)
            {
                cbxSerialPortList.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("没有获取到串口");
            }

            //var baudList = LoadBaudList();
            //cbxBaudRateList.Items.AddRange(baudList);
            //cbxBaudRateList.SelectedIndex = 5;

            //var dataBitList = LoadDataBitList();
            //cbxDataBitList.Items.AddRange(dataBitList);
            //cbxDataBitList.SelectedIndex = 3;

            //var stopBitList = LoadStopBitList();
            //txtStopBitList.Items.AddRange(stopBitList);
            //txtStopBitList.SelectedIndex = 1;

            //var checkBitList = LoadCheckBitList();
            //cbxCheckBitList.Items.AddRange(checkBitList);
            //cbxCheckBitList.SelectedIndex = 0;

            EnableSerialProtConfigUI(false);
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

        private string[] LoadBaudList()
        {
            return new string[] { "110" ,"300","1200","2400","4800","9600","19200","38400","57600","115200","230400","460800","921600"};
        }

        private string[] LoadDataBitList()
        {
            return new string[] { "5","6","7","8"};          
        }

        private string[] LoadStopBitList()
        {
            return new string[] { "None", "One", "Two", "OnePointFive" };
        }

        private string[] LoadCheckBitList()
        {
            return new string[] { "None", "Odd", "Even" , "Mark", "Space" };
        }

        private void ShowStatusText(string str)
        {
            this.BeginInvoke(new Action(()=> { toolStripStatusLabel1.Text = str; }));
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (cbxSerialPortList.Items.Count == 0)
            {
                return;
            }

            if(btnOpen.Text.Trim() == "打开")
            {
                portName = cbxSerialPortList.Text;
                baudRate = int.Parse(txtBaudRate.Text.Trim());
                dataBit = int.Parse(txtDataBit.Text.Trim());
                stopBit = int.Parse(txtStopBit.Text.Trim());
                parity = int.Parse(txtParity.Text.Trim());

                ConfigurationManagerHelpeor.AddUpdateAppSettings("portName", portName);
                ConfigurationManagerHelpeor.AddUpdateAppSettings("baudRate", baudRate.ToString());
                ConfigurationManagerHelpeor.AddUpdateAppSettings("dataBit", dataBit.ToString());
                ConfigurationManagerHelpeor.AddUpdateAppSettings("stopBit", stopBit.ToString());
                ConfigurationManagerHelpeor.AddUpdateAppSettings("parity", parity.ToString());
                var fm = (MainForm)this.Owner;
                fm.UpdateSerialPort(portName);

                fm.portName = portName;
                fm.baudRate = baudRate;
                fm.dataBit = dataBit;
                fm.stopBit = stopBit;
                fm.parity = parity;

                serialPort.CloseSerialPort();

                if (MessageBox.Show("修改串口信息后需要重新打开程序生效", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
                this.Close();
                return;

                var isOpen = false;
                try
                {
                    isOpen = serialPort.OpenSerialPort(portName, baudRate, dataBit, stopBit, parity, ReceiveData);
                }
                catch (Exception ex)
                {
                    ShowStatusText($"{portName}打开失败");
                    MessageBox.Show(ex.Message);
                    return;
                }
                if (isOpen)
                {
                    ShowStatusText($"{portName}打开成功");
                    EnableSerialProtConfigUI(true);
                    EnableConfigUI(false);
                    EnablePanel(0);
                    btnOpen.Text = "关闭";

                    var fm2 = (MainForm)this.Owner;
                    fm2.UpdateSerialPort(portName);

                    fm2.portName = portName;
                    fm2.baudRate = baudRate;
                    fm2.dataBit = dataBit;
                    fm2.stopBit = stopBit;
                    fm2.parity = parity;

                    serialPort.CloseSerialPort();
                    this.Close();
                    //MessageBox.Show("生成成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    //if (MessageBox.Show("生成成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    //{
                    //    //this.Close();
                    //}
                }
                else
                {
                    ShowStatusText($"{portName}打开失败");
                    EnableSerialProtConfigUI(false);
                }
            }
            else
            {
                if(serialPort.CloseSerialPort())
                {
                    EnableConfigUI(true);
                    btnOpen.Text = "打开";
                    ShowStatusText($"{this.cbxSerialPortList.Text.Trim()}关闭成功");
                }
                else
                {
                    ShowStatusText($"{this.cbxSerialPortList.Text.Trim()}关闭失败");
                }
            }
        }

        private void EnableSerialProtConfigUI(bool isEnable)
        {
            this.groupBox2.Enabled = isEnable;
            this.groupBox3.Enabled = isEnable;
            this.groupBox4.Enabled = isEnable;
            this.groupBox5.Enabled = isEnable;
            this.groupBox7.Enabled = isEnable;
        }

        private void EnableConfigUI(bool isEnable)
        {          
            //this.cbxBaudRateList.Enabled = isEnable;
            //this.cbxCheckBitList.Enabled = isEnable;
            //this.cbxDataBitList.Enabled = isEnable;
            //this.txtStopBitList.Enabled = isEnable;
            this.cbxSerialPortList.Enabled = isEnable;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(this.radioSendData.Checked)
            {
                var data = this.rtboxSendData.Text.Trim();
                var isHex = radioSendHEX.Checked ? true : false;
                var result = false;

                if (radioSendData.Checked)
                {
                    if (string.IsNullOrEmpty(this.rtboxSendData.Text.Trim()))
                    {
                        ShowStatusText("请输入要发送的数据");
                        return;
                    }

                    if (radioSendASCII.Checked)
                        result = serialPort.SendNormalString(data);
                    else
                        result = serialPort.SendHexString(data);
                }

                //ShowStatusText($"{DateTime.Now.ToString()} 发送{(result == true ? "成功":"失败")} ");
                ShowSendData(data + $"发送{(result == true ? "成功" : "失败")} ", true, true);
            }
            else
            {
                if(!System.IO.File.Exists(this.tboxFile.Text.Trim()))
                {
                    //ShowStatusText("文件不存在");
                    ShowSendData($"{this.tboxFile.Text.Trim()}文件不存在", true, true);
                    return;
                }

                var result = serialPort.SendFile(this.tboxFile.Text.Trim());
                ShowSendData($"文件发送{(result == true ? "成功" : "失败")} ", true, true);
            }
        }


        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "浏览文件";

            if(openDialog.ShowDialog() == DialogResult.OK)
            {
                this.tboxFile.Text = openDialog.FileName;
            }
        }

        private void ReceiveData(object sender, SerialDataReceivedEventArgs e)
        {
            var data = "";

            if (radioReceiveASCII.Checked)
            {
                data = serialPort.GetRawReceiveData();
            }
            else
            {
                data = serialPort.GetHexReceiveData();
            }

            ShowData(data, cbxReceiveAutoWrap.Checked, cbxReceiveShowTimeStamp.Checked);
        }

        private void ShowData(string data,bool isAutoWrap,bool isShowTimeStamp)
        {
            //if (!string.IsNullOrWhiteSpace(data))
            //{
            //    this.rtboxReceive.BeginInvoke(new Action(() => {

            //        if (isAutoWrap)
            //            data = data + Environment.NewLine;

            //        if (isShowTimeStamp)
            //            data = DateTime.Now.ToString() + "\t" + data;

            //        this.rtboxReceive.Text += data;
            //    }));
            //}
        }

        private void ShowSendData(string data, bool isAutoWrap, bool isShowTimeStamp)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    if (isAutoWrap)
                        data = data + Environment.NewLine;

                    if (isShowTimeStamp)
                        data = DateTime.Now.ToString() + "\t" + data;

                    this.rtboxSend.Text += data;
                }));
            }
            else
            {
                if (isAutoWrap)
                    data = data + Environment.NewLine;

                if (isShowTimeStamp)
                    data = DateTime.Now.ToString() + "\t" + data;

                this.rtboxSend.Text += data;
            }
        }


        private void ClearReceiveData()
        {
            this.rtboxReceive.Clear();
        }

        private void btnClearReceive_Click(object sender, EventArgs e)
        {
            ClearReceiveData();
        }


        private void radioSendData_CheckedChanged_1(object sender, EventArgs e)
        {
            if(radioSendData.Checked)
            {
                EnablePanel(0);
            }
        }

        private void EnablePanel(int index)
        {
            bool isPanel1Enable = false;
            bool isPanel3Enable = false;

            switch(index)
            {
                case 0:
                    isPanel1Enable = true;
                    break;
                case 2:
                    isPanel3Enable = true;
                    break;
            }

            this.panel1.Enabled = isPanel1Enable;
            this.panel3.Enabled = isPanel3Enable;
        }

        private void radioSendFile_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSendFile.Checked)
            {
                EnablePanel(2);
            }
        }

        private void cbxSplitMessage_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxSplitMessage.Checked)
            {
                tboxETXChar.Enabled = true;
            }
            else
            {
                tboxETXChar.Enabled = false;
            }
        }

        /// <summary>
        /// 关闭扫码成功提示音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            List<byte[]> codeList = new List<byte[]>();
            codeList.Add(NSet_Code_SETUPE1);
            codeList.Add(NSet_Code_GRBENA0);
            codeList.Add(NSet_Code_SETUPE0);
            Command("关闭扫码成功提示音", codeList);

        }

        /// <summary>
        /// 开启扫码成功提示音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            List<byte[]> codeList = new List<byte[]>();
            codeList.Add(NSet_Code_SETUPE1);
            codeList.Add(NSet_Code_GRBENA1);
            codeList.Add(NSet_Code_SETUPE0);
            Command("开启扫码成功提示音", codeList);
        }

        /// <summary>
        /// 启用扫描二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            List<byte[]> codeList = new List<byte[]>();
            codeList.Add(NSet_Code_SETUPE1);
            codeList.Add(NSet_Code_ALLENA0);
            codeList.Add(NSet_Code_ALL2DC1);
            codeList.Add(NSet_Code_SETUPE0);
            Command("启用扫描二维码", codeList);
        }

        /// <summary>
        /// 启用扫描条形码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            List<byte[]> codeList = new List<byte[]>();
            codeList.Add(NSet_Code_SETUPE1);
            codeList.Add(NSet_Code_ALLENA0);
            codeList.Add(NSet_Code_ALL1DC1);
            codeList.Add(NSet_Code_SETUPE0);
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
                    Thread.Sleep(500);
                    if (!result)
                    {
                        break;
                    }
                }
                if (!result)
                {
                    ShowSendData(str + $"发送失败", true, true);
                }
            }
            catch (Exception ex)
            {
                ShowSendData(str + $"发送失败:{ex.Message} ", true, true);
                return;
            }
            ShowSendData(str + $"发送{(result == true ? "成功" : "失败")} ", true, true);

        }

        /// <summary>
        /// 启用感应模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            List<byte[]> codeList = new List<byte[]>();
            codeList.Add(NSet_Code_SETUPE1);
            codeList.Add(NSet_Code_SCNMOD2);
            codeList.Add(NSet_Code_SENLVL8);
            codeList.Add(NSet_Code_SETUPE0);
            Command("启用感应模式", codeList);
        }

        private void SerialPortSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void SerialPortSetting_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < portList.Length; i++)
            {
                if (portList[i] == portName)
                {
                    cbxSerialPortList.SelectedItem = portList[i];
                    break;
                }
            }

            btnOpen.Text = "打开";
        }
    }
}
