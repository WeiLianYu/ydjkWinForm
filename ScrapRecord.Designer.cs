namespace 移动家客WinApp
{
    partial class ScrapRecord
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtsn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvScrapRecord = new System.Windows.Forms.DataGridView();
            this.createtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.snnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AreaName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.terminalstatename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realityname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.cbxarea2 = new System.Windows.Forms.ComboBox();
            this.cbxarea1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScrapRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // txtsn
            // 
            this.txtsn.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.txtsn.Location = new System.Drawing.Point(116, 57);
            this.txtsn.Name = "txtsn";
            this.txtsn.Size = new System.Drawing.Size(581, 38);
            this.txtsn.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "SN码：";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(719, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvScrapRecord
            // 
            this.dgvScrapRecord.AllowUserToAddRows = false;
            this.dgvScrapRecord.AllowUserToDeleteRows = false;
            this.dgvScrapRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScrapRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.createtime,
            this.snnum,
            this.AreaName2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.terminalstatename,
            this.realityname,
            this.Id});
            this.dgvScrapRecord.Location = new System.Drawing.Point(12, 112);
            this.dgvScrapRecord.Name = "dgvScrapRecord";
            this.dgvScrapRecord.ReadOnly = true;
            this.dgvScrapRecord.RowTemplate.Height = 23;
            this.dgvScrapRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvScrapRecord.Size = new System.Drawing.Size(979, 618);
            this.dgvScrapRecord.TabIndex = 3;
            this.dgvScrapRecord.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScrapRecord_CellContentClick);
            this.dgvScrapRecord.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvScrapRecord_RowPostPaint);
            // 
            // createtime
            // 
            this.createtime.DataPropertyName = "createtime";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.createtime.DefaultCellStyle = dataGridViewCellStyle1;
            this.createtime.HeaderText = "创建日期";
            this.createtime.Name = "createtime";
            this.createtime.ReadOnly = true;
            this.createtime.Width = 160;
            // 
            // snnum
            // 
            this.snnum.DataPropertyName = "snnum";
            this.snnum.HeaderText = "SN码";
            this.snnum.Name = "snnum";
            this.snnum.ReadOnly = true;
            this.snnum.Width = 400;
            // 
            // AreaName2
            // 
            this.AreaName2.DataPropertyName = "AreaName2";
            this.AreaName2.HeaderText = "区县";
            this.AreaName2.Name = "AreaName2";
            this.AreaName2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "厂家";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "类型";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "型号";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // terminalstatename
            // 
            this.terminalstatename.DataPropertyName = "terminalstatename";
            this.terminalstatename.HeaderText = "状态";
            this.terminalstatename.Name = "terminalstatename";
            this.terminalstatename.ReadOnly = true;
            // 
            // realityname
            // 
            this.realityname.DataPropertyName = "realityname";
            this.realityname.HeaderText = "创建人";
            this.realityname.Name = "realityname";
            this.realityname.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(865, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 38);
            this.button2.TabIndex = 4;
            this.button2.Text = "返回";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbxarea2
            // 
            this.cbxarea2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxarea2.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.cbxarea2.FormattingEnabled = true;
            this.cbxarea2.Location = new System.Drawing.Point(493, 6);
            this.cbxarea2.Name = "cbxarea2";
            this.cbxarea2.Size = new System.Drawing.Size(204, 35);
            this.cbxarea2.TabIndex = 45;
            // 
            // cbxarea1
            // 
            this.cbxarea1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxarea1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.cbxarea1.FormattingEnabled = true;
            this.cbxarea1.Location = new System.Drawing.Point(114, 6);
            this.cbxarea1.Name = "cbxarea1";
            this.cbxarea1.Size = new System.Drawing.Size(279, 35);
            this.cbxarea1.TabIndex = 44;
            this.cbxarea1.SelectedIndexChanged += new System.EventHandler(this.cbxarea1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(417, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 27);
            this.label7.TabIndex = 43;
            this.label7.Text = "县市：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 27);
            this.label2.TabIndex = 42;
            this.label2.Text = "地市：";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(719, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 38);
            this.button3.TabIndex = 46;
            this.button3.Text = "生成唯一码";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ScrapRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 742);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cbxarea2);
            this.Controls.Add(this.cbxarea1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dgvScrapRecord);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtsn);
            this.Name = "ScrapRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "移动家客--报废记录";
            this.Load += new System.EventHandler(this.ScrapRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScrapRecord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtsn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvScrapRecord;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbxarea2;
        private System.Windows.Forms.ComboBox cbxarea1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn createtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn snnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaName2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn terminalstatename;
        private System.Windows.Forms.DataGridViewTextBoxColumn realityname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.Button button3;
    }
}