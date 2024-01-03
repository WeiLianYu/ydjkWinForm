namespace 移动家客WinApp
{
    partial class SealingBoxAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxarea2 = new System.Windows.Forms.ComboBox();
            this.cbxarea1 = new System.Windows.Forms.ComboBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxSortType = new System.Windows.Forms.ComboBox();
            this.cbxTerminalModel = new System.Windows.Forms.ComboBox();
            this.cbxManufactor = new System.Windows.Forms.ComboBox();
            this.cbxTerminalType = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLogisticsNum = new System.Windows.Forms.Button();
            this.btnBatchNum = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtFX_Logistics_LogisticsNum = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFX_Logistics_BatchNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxarea2);
            this.groupBox1.Controls.Add(this.cbxarea1);
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbxSortType);
            this.groupBox1.Controls.Add(this.cbxTerminalModel);
            this.groupBox1.Controls.Add(this.cbxManufactor);
            this.groupBox1.Controls.Add(this.cbxTerminalType);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnLogisticsNum);
            this.groupBox1.Controls.Add(this.btnBatchNum);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtFX_Logistics_LogisticsNum);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtFX_Logistics_BatchNum);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1055, 258);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加物流单";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(180, 103);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(361, 41);
            this.dateTimePicker1.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 30);
            this.label1.TabIndex = 43;
            this.label1.Text = "日期：";
            // 
            // cbxarea2
            // 
            this.cbxarea2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxarea2.FormattingEnabled = true;
            this.cbxarea2.Location = new System.Drawing.Point(732, 43);
            this.cbxarea2.Name = "cbxarea2";
            this.cbxarea2.Size = new System.Drawing.Size(291, 37);
            this.cbxarea2.TabIndex = 41;
            // 
            // cbxarea1
            // 
            this.cbxarea1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxarea1.FormattingEnabled = true;
            this.cbxarea1.Location = new System.Drawing.Point(180, 43);
            this.cbxarea1.Name = "cbxarea1";
            this.cbxarea1.Size = new System.Drawing.Size(361, 37);
            this.cbxarea1.TabIndex = 40;
            this.cbxarea1.SelectedIndexChanged += new System.EventHandler(this.cbxarea1_SelectedIndexChanged);
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(180, 509);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(1063, 168);
            this.txtRemark.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 509);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 30);
            this.label6.TabIndex = 38;
            this.label6.Text = "备注：";
            // 
            // cbxSortType
            // 
            this.cbxSortType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSortType.FormattingEnabled = true;
            this.cbxSortType.Location = new System.Drawing.Point(829, 320);
            this.cbxSortType.Name = "cbxSortType";
            this.cbxSortType.Size = new System.Drawing.Size(291, 37);
            this.cbxSortType.TabIndex = 37;
            // 
            // cbxTerminalModel
            // 
            this.cbxTerminalModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTerminalModel.FormattingEnabled = true;
            this.cbxTerminalModel.Location = new System.Drawing.Point(180, 320);
            this.cbxTerminalModel.Name = "cbxTerminalModel";
            this.cbxTerminalModel.Size = new System.Drawing.Size(291, 37);
            this.cbxTerminalModel.TabIndex = 36;
            // 
            // cbxManufactor
            // 
            this.cbxManufactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxManufactor.FormattingEnabled = true;
            this.cbxManufactor.Location = new System.Drawing.Point(829, 259);
            this.cbxManufactor.Name = "cbxManufactor";
            this.cbxManufactor.Size = new System.Drawing.Size(291, 37);
            this.cbxManufactor.TabIndex = 35;
            this.cbxManufactor.SelectedIndexChanged += new System.EventHandler(this.cbxManufactor_SelectedIndexChanged);
            // 
            // cbxTerminalType
            // 
            this.cbxTerminalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTerminalType.FormattingEnabled = true;
            this.cbxTerminalType.Location = new System.Drawing.Point(180, 259);
            this.cbxTerminalType.Name = "cbxTerminalType";
            this.cbxTerminalType.Size = new System.Drawing.Size(291, 37);
            this.cbxTerminalType.TabIndex = 34;
            this.cbxTerminalType.SelectedIndexChanged += new System.EventHandler(this.cbxTerminalType_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(625, 198);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(160, 54);
            this.btnClose.TabIndex = 33;
            this.btnClose.Text = "返回";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLogisticsNum
            // 
            this.btnLogisticsNum.Location = new System.Drawing.Point(1135, 430);
            this.btnLogisticsNum.Name = "btnLogisticsNum";
            this.btnLogisticsNum.Size = new System.Drawing.Size(108, 54);
            this.btnLogisticsNum.TabIndex = 32;
            this.btnLogisticsNum.Text = "选择";
            this.btnLogisticsNum.UseVisualStyleBackColor = true;
            // 
            // btnBatchNum
            // 
            this.btnBatchNum.Location = new System.Drawing.Point(1135, 368);
            this.btnBatchNum.Name = "btnBatchNum";
            this.btnBatchNum.Size = new System.Drawing.Size(108, 54);
            this.btnBatchNum.TabIndex = 28;
            this.btnBatchNum.Text = "选择";
            this.btnBatchNum.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(381, 198);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 54);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtFX_Logistics_LogisticsNum
            // 
            this.txtFX_Logistics_LogisticsNum.Location = new System.Drawing.Point(180, 440);
            this.txtFX_Logistics_LogisticsNum.Name = "txtFX_Logistics_LogisticsNum";
            this.txtFX_Logistics_LogisticsNum.Size = new System.Drawing.Size(940, 41);
            this.txtFX_Logistics_LogisticsNum.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 443);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(168, 30);
            this.label10.TabIndex = 19;
            this.label10.Text = "物流单号：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(655, 323);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(168, 30);
            this.label9.TabIndex = 18;
            this.label9.Text = "终端状态：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(655, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(168, 30);
            this.label8.TabIndex = 14;
            this.label8.Text = "终端厂家：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(620, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 30);
            this.label7.TabIndex = 12;
            this.label7.Text = "县市：";
            // 
            // txtFX_Logistics_BatchNum
            // 
            this.txtFX_Logistics_BatchNum.Location = new System.Drawing.Point(180, 378);
            this.txtFX_Logistics_BatchNum.Name = "txtFX_Logistics_BatchNum";
            this.txtFX_Logistics_BatchNum.Size = new System.Drawing.Size(940, 41);
            this.txtFX_Logistics_BatchNum.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 389);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 30);
            this.label5.TabIndex = 4;
            this.label5.Text = "批次号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "终端型号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "终端类型：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "地市：";
            // 
            // SealingBoxAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 284);
            this.Controls.Add(this.groupBox1);
            this.Name = "SealingBoxAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "移动家客--新增物流单";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SealingBoxAdd_FormClosed);
            this.Load += new System.EventHandler(this.SealingBoxAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFX_Logistics_BatchNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFX_Logistics_LogisticsNum;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBatchNum;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnLogisticsNum;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxarea2;
        private System.Windows.Forms.ComboBox cbxarea1;
        private System.Windows.Forms.ComboBox cbxSortType;
        private System.Windows.Forms.ComboBox cbxTerminalModel;
        private System.Windows.Forms.ComboBox cbxManufactor;
        private System.Windows.Forms.ComboBox cbxTerminalType;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
    }
}