namespace 移动家客WinApp
{
    partial class SerialPortSetting
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialPortSetting));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnClearReceive = new System.Windows.Forms.Button();
            this.rtboxReceive = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtboxSend = new System.Windows.Forms.TextBox();
            this.radioSendData = new System.Windows.Forms.RadioButton();
            this.radioSendFile = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtboxSendData = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tboxFile = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboxRepeatTimeSpanList = new System.Windows.Forms.ComboBox();
            this.cbxSendAutoRepeat = new System.Windows.Forms.CheckBox();
            this.radioSendHEX = new System.Windows.Forms.RadioButton();
            this.radioSendASCII = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tboxETXChar = new System.Windows.Forms.TextBox();
            this.cbxSplitMessage = new System.Windows.Forms.CheckBox();
            this.cbxReceiveShowTimeStamp = new System.Windows.Forms.CheckBox();
            this.cbxReceiveAutoWrap = new System.Windows.Forms.CheckBox();
            this.radioReceiveHEX = new System.Windows.Forms.RadioButton();
            this.radioReceiveASCII = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxSerialPortList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBaudRate = new System.Windows.Forms.TextBox();
            this.txtDataBit = new System.Windows.Forms.TextBox();
            this.txtStopBit = new System.Windows.Forms.TextBox();
            this.txtParity = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 793);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1309, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1285, 770);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "扫码枪设置";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button2);
            this.groupBox7.Controls.Add(this.button4);
            this.groupBox7.Controls.Add(this.button1);
            this.groupBox7.Controls.Add(this.button5);
            this.groupBox7.Controls.Add(this.button3);
            this.groupBox7.Location = new System.Drawing.Point(417, 44);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(270, 715);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "指令";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 304);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(209, 60);
            this.button2.TabIndex = 30;
            this.button2.Text = "开启提示音";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(22, 172);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(209, 60);
            this.button4.TabIndex = 32;
            this.button4.Text = " 条形码";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 60);
            this.button1.TabIndex = 29;
            this.button1.Text = "关闭提示音";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(22, 40);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(209, 60);
            this.button5.TabIndex = 33;
            this.button5.Text = "感应模式";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(22, 106);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(209, 60);
            this.button3.TabIndex = 31;
            this.button3.Text = "二维码";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnClearReceive);
            this.groupBox5.Controls.Add(this.rtboxReceive);
            this.groupBox5.Location = new System.Drawing.Point(693, 375);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(586, 384);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "接收";
            // 
            // btnClearReceive
            // 
            this.btnClearReceive.Location = new System.Drawing.Point(447, 331);
            this.btnClearReceive.Name = "btnClearReceive";
            this.btnClearReceive.Size = new System.Drawing.Size(133, 41);
            this.btnClearReceive.TabIndex = 1;
            this.btnClearReceive.Text = "清空";
            this.btnClearReceive.UseVisualStyleBackColor = true;
            // 
            // rtboxReceive
            // 
            this.rtboxReceive.Location = new System.Drawing.Point(69, 40);
            this.rtboxReceive.Name = "rtboxReceive";
            this.rtboxReceive.Size = new System.Drawing.Size(511, 285);
            this.rtboxReceive.TabIndex = 0;
            this.rtboxReceive.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rtboxSend);
            this.groupBox4.Controls.Add(this.radioSendData);
            this.groupBox4.Controls.Add(this.radioSendFile);
            this.groupBox4.Controls.Add(this.panel1);
            this.groupBox4.Controls.Add(this.panel3);
            this.groupBox4.Location = new System.Drawing.Point(693, 44);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(586, 325);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "发送";
            // 
            // rtboxSend
            // 
            this.rtboxSend.Location = new System.Drawing.Point(196, 85);
            this.rtboxSend.Multiline = true;
            this.rtboxSend.Name = "rtboxSend";
            this.rtboxSend.Size = new System.Drawing.Size(384, 147);
            this.rtboxSend.TabIndex = 28;
            // 
            // radioSendData
            // 
            this.radioSendData.AutoSize = true;
            this.radioSendData.Checked = true;
            this.radioSendData.Location = new System.Drawing.Point(12, 40);
            this.radioSendData.Name = "radioSendData";
            this.radioSendData.Size = new System.Drawing.Size(155, 34);
            this.radioSendData.TabIndex = 6;
            this.radioSendData.TabStop = true;
            this.radioSendData.Text = "发送数据";
            this.radioSendData.UseVisualStyleBackColor = true;
            // 
            // radioSendFile
            // 
            this.radioSendFile.AutoSize = true;
            this.radioSendFile.Location = new System.Drawing.Point(12, 259);
            this.radioSendFile.Name = "radioSendFile";
            this.radioSendFile.Size = new System.Drawing.Size(155, 34);
            this.radioSendFile.TabIndex = 7;
            this.radioSendFile.Text = "发送文件";
            this.radioSendFile.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rtboxSendData);
            this.panel1.Location = new System.Drawing.Point(173, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 59);
            this.panel1.TabIndex = 25;
            // 
            // rtboxSendData
            // 
            this.rtboxSendData.Location = new System.Drawing.Point(23, 20);
            this.rtboxSendData.Name = "rtboxSendData";
            this.rtboxSendData.Size = new System.Drawing.Size(384, 25);
            this.rtboxSendData.TabIndex = 1;
            this.rtboxSendData.Text = "";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tboxFile);
            this.panel3.Controls.Add(this.btnSend);
            this.panel3.Location = new System.Drawing.Point(170, 250);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(515, 68);
            this.panel3.TabIndex = 27;
            // 
            // tboxFile
            // 
            this.tboxFile.Location = new System.Drawing.Point(26, 14);
            this.tboxFile.Name = "tboxFile";
            this.tboxFile.Size = new System.Drawing.Size(257, 41);
            this.tboxFile.TabIndex = 4;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(296, 14);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(114, 44);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboxRepeatTimeSpanList);
            this.groupBox3.Controls.Add(this.cbxSendAutoRepeat);
            this.groupBox3.Controls.Add(this.radioSendHEX);
            this.groupBox3.Controls.Add(this.radioSendASCII);
            this.groupBox3.Location = new System.Drawing.Point(7, 340);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(403, 146);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送设置";
            // 
            // cboxRepeatTimeSpanList
            // 
            this.cboxRepeatTimeSpanList.FormattingEnabled = true;
            this.cboxRepeatTimeSpanList.Location = new System.Drawing.Point(227, 81);
            this.cboxRepeatTimeSpanList.Name = "cboxRepeatTimeSpanList";
            this.cboxRepeatTimeSpanList.Size = new System.Drawing.Size(83, 37);
            this.cboxRepeatTimeSpanList.TabIndex = 3;
            // 
            // cbxSendAutoRepeat
            // 
            this.cbxSendAutoRepeat.AutoSize = true;
            this.cbxSendAutoRepeat.Location = new System.Drawing.Point(65, 80);
            this.cbxSendAutoRepeat.Name = "cbxSendAutoRepeat";
            this.cbxSendAutoRepeat.Size = new System.Drawing.Size(156, 34);
            this.cbxSendAutoRepeat.TabIndex = 2;
            this.cbxSendAutoRepeat.Text = "重复发送";
            this.cbxSendAutoRepeat.UseVisualStyleBackColor = true;
            // 
            // radioSendHEX
            // 
            this.radioSendHEX.AutoSize = true;
            this.radioSendHEX.Location = new System.Drawing.Point(227, 40);
            this.radioSendHEX.Name = "radioSendHEX";
            this.radioSendHEX.Size = new System.Drawing.Size(79, 34);
            this.radioSendHEX.TabIndex = 1;
            this.radioSendHEX.Text = "HEX";
            this.radioSendHEX.UseVisualStyleBackColor = true;
            // 
            // radioSendASCII
            // 
            this.radioSendASCII.AutoSize = true;
            this.radioSendASCII.Checked = true;
            this.radioSendASCII.Location = new System.Drawing.Point(69, 40);
            this.radioSendASCII.Name = "radioSendASCII";
            this.radioSendASCII.Size = new System.Drawing.Size(111, 34);
            this.radioSendASCII.TabIndex = 0;
            this.radioSendASCII.TabStop = true;
            this.radioSendASCII.Text = "ASCII";
            this.radioSendASCII.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tboxETXChar);
            this.groupBox2.Controls.Add(this.cbxSplitMessage);
            this.groupBox2.Controls.Add(this.cbxReceiveShowTimeStamp);
            this.groupBox2.Controls.Add(this.cbxReceiveAutoWrap);
            this.groupBox2.Controls.Add(this.radioReceiveHEX);
            this.groupBox2.Controls.Add(this.radioReceiveASCII);
            this.groupBox2.Location = new System.Drawing.Point(7, 492);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 267);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收设置";
            // 
            // tboxETXChar
            // 
            this.tboxETXChar.Location = new System.Drawing.Point(295, 220);
            this.tboxETXChar.Name = "tboxETXChar";
            this.tboxETXChar.Size = new System.Drawing.Size(100, 41);
            this.tboxETXChar.TabIndex = 5;
            this.tboxETXChar.Text = "03";
            // 
            // cbxSplitMessage
            // 
            this.cbxSplitMessage.AutoSize = true;
            this.cbxSplitMessage.Checked = true;
            this.cbxSplitMessage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSplitMessage.Location = new System.Drawing.Point(10, 221);
            this.cbxSplitMessage.Name = "cbxSplitMessage";
            this.cbxSplitMessage.Size = new System.Drawing.Size(280, 34);
            this.cbxSplitMessage.TabIndex = 4;
            this.cbxSplitMessage.Text = "自动分隔连续消息";
            this.cbxSplitMessage.UseVisualStyleBackColor = true;
            // 
            // cbxReceiveShowTimeStamp
            // 
            this.cbxReceiveShowTimeStamp.AutoSize = true;
            this.cbxReceiveShowTimeStamp.Checked = true;
            this.cbxReceiveShowTimeStamp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxReceiveShowTimeStamp.Location = new System.Drawing.Point(6, 157);
            this.cbxReceiveShowTimeStamp.Name = "cbxReceiveShowTimeStamp";
            this.cbxReceiveShowTimeStamp.Size = new System.Drawing.Size(187, 34);
            this.cbxReceiveShowTimeStamp.TabIndex = 3;
            this.cbxReceiveShowTimeStamp.Text = "显示时间戳";
            this.cbxReceiveShowTimeStamp.UseVisualStyleBackColor = true;
            // 
            // cbxReceiveAutoWrap
            // 
            this.cbxReceiveAutoWrap.AutoSize = true;
            this.cbxReceiveAutoWrap.Checked = true;
            this.cbxReceiveAutoWrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxReceiveAutoWrap.Location = new System.Drawing.Point(10, 101);
            this.cbxReceiveAutoWrap.Name = "cbxReceiveAutoWrap";
            this.cbxReceiveAutoWrap.Size = new System.Drawing.Size(156, 34);
            this.cbxReceiveAutoWrap.TabIndex = 2;
            this.cbxReceiveAutoWrap.Text = "自动换行";
            this.cbxReceiveAutoWrap.UseVisualStyleBackColor = true;
            // 
            // radioReceiveHEX
            // 
            this.radioReceiveHEX.AutoSize = true;
            this.radioReceiveHEX.Location = new System.Drawing.Point(146, 40);
            this.radioReceiveHEX.Name = "radioReceiveHEX";
            this.radioReceiveHEX.Size = new System.Drawing.Size(79, 34);
            this.radioReceiveHEX.TabIndex = 1;
            this.radioReceiveHEX.Text = "HEX";
            this.radioReceiveHEX.UseVisualStyleBackColor = true;
            // 
            // radioReceiveASCII
            // 
            this.radioReceiveASCII.AutoSize = true;
            this.radioReceiveASCII.Checked = true;
            this.radioReceiveASCII.Location = new System.Drawing.Point(10, 40);
            this.radioReceiveASCII.Name = "radioReceiveASCII";
            this.radioReceiveASCII.Size = new System.Drawing.Size(111, 34);
            this.radioReceiveASCII.TabIndex = 0;
            this.radioReceiveASCII.TabStop = true;
            this.radioReceiveASCII.Text = "ASCII";
            this.radioReceiveASCII.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtParity);
            this.groupBox6.Controls.Add(this.txtStopBit);
            this.groupBox6.Controls.Add(this.txtDataBit);
            this.groupBox6.Controls.Add(this.txtBaudRate);
            this.groupBox6.Controls.Add(this.btnOpen);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.cbxSerialPortList);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Location = new System.Drawing.Point(6, 44);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(404, 290);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "串口信息";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(295, 54);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(103, 39);
            this.btnOpen.TabIndex = 10;
            this.btnOpen.Text = "打开";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 30);
            this.label5.TabIndex = 8;
            this.label5.Text = "检验位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 30);
            this.label4.TabIndex = 6;
            this.label4.Text = "停止位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "数据位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率";
            // 
            // cbxSerialPortList
            // 
            this.cbxSerialPortList.FormattingEnabled = true;
            this.cbxSerialPortList.Location = new System.Drawing.Point(118, 56);
            this.cbxSerialPortList.Name = "cbxSerialPortList";
            this.cbxSerialPortList.Size = new System.Drawing.Size(168, 37);
            this.cbxSerialPortList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号";
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.Location = new System.Drawing.Point(118, 99);
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.ReadOnly = true;
            this.txtBaudRate.Size = new System.Drawing.Size(168, 41);
            this.txtBaudRate.TabIndex = 11;
            this.txtBaudRate.Text = "9600";
            // 
            // txtDataBit
            // 
            this.txtDataBit.Location = new System.Drawing.Point(118, 145);
            this.txtDataBit.Name = "txtDataBit";
            this.txtDataBit.ReadOnly = true;
            this.txtDataBit.Size = new System.Drawing.Size(168, 41);
            this.txtDataBit.TabIndex = 12;
            this.txtDataBit.Text = "8";
            // 
            // txtStopBit
            // 
            this.txtStopBit.Location = new System.Drawing.Point(118, 194);
            this.txtStopBit.Name = "txtStopBit";
            this.txtStopBit.ReadOnly = true;
            this.txtStopBit.Size = new System.Drawing.Size(168, 41);
            this.txtStopBit.TabIndex = 13;
            this.txtStopBit.Text = "1";
            // 
            // txtParity
            // 
            this.txtParity.Location = new System.Drawing.Point(118, 241);
            this.txtParity.Name = "txtParity";
            this.txtParity.ReadOnly = true;
            this.txtParity.Size = new System.Drawing.Size(168, 41);
            this.txtParity.TabIndex = 14;
            this.txtParity.Text = "0";
            // 
            // SerialPortSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 815);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SerialPortSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "串口助手";
            this.Load += new System.EventHandler(this.SerialPortSetting_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnClearReceive;
        private System.Windows.Forms.RichTextBox rtboxReceive;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox rtboxSend;
        private System.Windows.Forms.RadioButton radioSendData;
        private System.Windows.Forms.RadioButton radioSendFile;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtboxSendData;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tboxFile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboxRepeatTimeSpanList;
        private System.Windows.Forms.CheckBox cbxSendAutoRepeat;
        private System.Windows.Forms.RadioButton radioSendHEX;
        private System.Windows.Forms.RadioButton radioSendASCII;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tboxETXChar;
        private System.Windows.Forms.CheckBox cbxSplitMessage;
        private System.Windows.Forms.CheckBox cbxReceiveShowTimeStamp;
        private System.Windows.Forms.CheckBox cbxReceiveAutoWrap;
        private System.Windows.Forms.RadioButton radioReceiveHEX;
        private System.Windows.Forms.RadioButton radioReceiveASCII;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxSerialPortList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBaudRate;
        private System.Windows.Forms.TextBox txtDataBit;
        private System.Windows.Forms.TextBox txtStopBit;
        private System.Windows.Forms.TextBox txtParity;
    }
}

