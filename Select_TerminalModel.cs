using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 移动家客WinApp.Business.IService;
using 移动家客WinApp.Business.Service;
using 移动家客WinApp.Model.Input.Terminal;
using 移动家客WinApp.Model.Output.System;
using 移动家客WinApp.Model.Output.Terminal;

namespace 移动家客WinApp
{
    public partial class Select_TerminalModel : Form
    {
        private ITerminalModelService _TerminalModel;
        private string Initial = string.Empty;
        private IDictionaryService _Dictionary;

        public Select_TerminalModel()
        {
            InitializeComponent();

            _TerminalModel = new TerminalModelService();
            _Dictionary = new DictionaryService();
        }


        private void Select_TerminalModel_Load(object sender, EventArgs e)
        {

            //DictionaryDto Manufactors = new DictionaryDto();
            //try
            //{
            //    Manufactors = await _Dictionary.GetList("Manufactor");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //Manufactors.list.Insert(0, new DictionaryInfo() { text = "--请选择--", value = 0 });
            //cbxManufactor.DataSource = Manufactors.list;
            //cbxManufactor.DisplayMember = "text";
            //cbxManufactor.ValueMember = "value";
            //if (cbxManufactor.Items.Count > 0)
            //{                
            //    cbxManufactor.SelectedIndex = 0;
            //}

            DataBind_dgv_Initials();
            DataBind_dgv_data();
            DataBind_dgvdata2();

            txtzf.Focus();
        }

        private void DataBind_dgv_Initials()
        {
            //行高自适应
            dgv_Initials.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgv_Initials.AutoGenerateColumns = false;
            dgv_Initials.Font = new Font("微软雅黑", 15);

            var query = from a in MainForm.TerminalModelList
                        group a by a.model.Substring(0, 1).ToUpper() into g
                        select new
                        {
                            Initials = g.Key
                        };

            this.dgv_Initials.DataSource = query.ToList();
        }

        private void dgv_Initials_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //序号
            //Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
            //   e.RowBounds.Location.Y,
            //   dgv_Initials.RowHeadersWidth - 4,
            //   e.RowBounds.Height);
            //TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            //    dgv_Initials.RowHeadersDefaultCellStyle.Font,
            //    rectangle,
            //    dgv_Initials.RowHeadersDefaultCellStyle.ForeColor,
            //    TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void DataBind_dgvdata(DataGridView dgv, int PageSize = 1000, int PageIndex = 1)
        {
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgv.AutoGenerateColumns = false;
            dgv.Font = new Font("微软雅黑", 15);

            //int ManufactorId = 0;
            var query = MainForm.TerminalModelList;
            //try
            //{
            //    var Manufactor = cbxManufactor.SelectedValue as DictionaryInfo;
            //    if (Manufactor != null)
            //    {
            //        ManufactorId = Manufactor.value;
            //    }
            //    else
            //    {
            //        ManufactorId = (int)cbxManufactor.SelectedValue;
            //    }
            //    if (ManufactorId > 0)
            //    {
            //        query = query.Where(p => p.manufactor == ManufactorId).ToList();
            //    }
            //}
            //catch { }

            try
            {
                if (!string.IsNullOrEmpty(Initial))
                {
                    query = query.OrderBy(p => p.terminaltype).Where(p => p.model.Trim().ToUpper().Contains(Initial.Trim().ToUpper())).Take(PageSize * PageIndex).Skip(PageSize * (PageIndex - 1)).ToList();
                }
                else
                {
                    query = query.OrderBy(p => p.terminaltype).Take(PageSize * PageIndex).Skip(PageSize * (PageIndex - 1)).ToList();
                }

                dgv.DataSource = query;
            }
            catch {
                dgv.DataSource = new List<TerminalModelInfo>();
            }
        }

        private void DataBind_dgvdata2()
        {
            dgv_data2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgv_data2.AutoGenerateColumns = false;
            dgv_data2.Font = new Font("微软雅黑", 15);

            var query = MainForm.TerminalModels.Values.ToList();

            try
            {
                if (!string.IsNullOrEmpty(Initial))
                {
                    query = query.Where(p => p.model.Trim().ToUpper().Contains(Initial.Trim().ToUpper())).ToList();
                }

                dgv_data2.DataSource = query;
            }
            catch
            {
                dgv_data2.DataSource = new List<TerminalModelInfo>();
            }
        }

        private void DataBind_dgv_data()
        {
            DataBind_dgvdata(dgv_data1);
            //DataBind_dgvdata(dgv_data2, 20, 2);
            //DataBind_dgvdata(dgv_data3, 20, 3);
            //DataBind_dgvdata(dgv_data4, 20, 4);
            //DataBind_dgvdata(dgv_data5, 20, 5);
        }

        private void AddDataGridViewColumn()
        {
            ////为dgv增加一列按钮
            //DataGridViewButtonColumn btn0 = new DataGridViewButtonColumn();
            //btn0.Name = "BtnSelect";    //设置列的名称
            //btn0.Text = "选择";     //按钮上的文字属性
            //btn0.DefaultCellStyle.NullValue = "选择";
            //btn0.HeaderText = "操作";     //显示的列名
            //this.dgv_Initials.Columns.Insert(0, btn0); //在dataGridView1的最后一列添加按钮
            //this.dgv_Initials.Columns[0].Width = 70;

            //var btn1 = new DataGridViewButtonColumn();
            //btn1.Name = "BtnSelect";    //设置列的名称
            //btn1.Text = "选择";     //按钮上的文字属性
            //btn1.DefaultCellStyle.NullValue = "选择";
            //btn1.HeaderText = "操作";     //显示的列名
            //this.dgv_data1.Columns.Insert(0, btn1); //在dataGridView1的最后一列添加按钮
            //this.dgv_data1.Columns[0].Width = 70;

            //var btn2 = new DataGridViewButtonColumn();
            //btn2.Name = "BtnSelect";    //设置列的名称
            //btn2.Text = "选择";     //按钮上的文字属性
            //btn2.DefaultCellStyle.NullValue = "选择";
            //btn2.HeaderText = "操作";     //显示的列名            
            //this.dgv_data2.Columns.Insert(0, btn2); //在dataGridView1的最后一列添加按钮
            //this.dgv_data2.Columns[0].Width = 70;

            //var btn3 = new DataGridViewButtonColumn();
            //btn3.Name = "BtnSelect";    //设置列的名称
            //btn3.Text = "选择";     //按钮上的文字属性
            //btn3.DefaultCellStyle.NullValue = "选择";
            //btn3.HeaderText = "操作";     //显示的列名   
            //this.dgv_data3.Columns.Insert(0, btn3); //在dataGridView1的最后一列添加按钮
            //this.dgv_data3.Columns[0].Width = 70;

            //var btn4 = new DataGridViewButtonColumn();
            //btn4.Name = "BtnSelect";    //设置列的名称
            //btn4.Text = "选择";     //按钮上的文字属性
            //btn4.DefaultCellStyle.NullValue = "选择";
            //btn4.HeaderText = "操作";     //显示的列名   
            //this.dgv_data4.Columns.Insert(0, btn4); //在dataGridView1的最后一列添加按钮
            //this.dgv_data4.Columns[0].Width = 70;

            //var btn5 = new DataGridViewButtonColumn();
            //btn5.Name = "BtnSelect";    //设置列的名称
            //btn5.Text = "选择";     //按钮上的文字属性
            //btn5.DefaultCellStyle.NullValue = "选择";
            //btn5.HeaderText = "操作";     //显示的列名   
            //this.dgv_data5.Columns.Insert(0, btn5); //在dataGridView1的最后一列添加按钮
            //this.dgv_data5.Columns[0].Width = 70;
        }

        private void dgv_Initials_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dgv_data1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var Id1 = dgv_data1.CurrentRow.Cells["Id1"].Value.ToString();

            var fm = (MainForm)this.Owner;
            fm.TerminalModel = MainForm.TerminalModelList.Where(p => p.Id == int.Parse(Id1)).FirstOrDefault();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dgv_data2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var Id1 = dgv_data2.CurrentRow.Cells["Id2"].Value.ToString();

            var fm = (MainForm)this.Owner;
            fm.TerminalModel = MainForm.TerminalModelList.Where(p => p.Id == int.Parse(Id1)).FirstOrDefault();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dgv_data3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //var Id1 = dgv_data3.CurrentRow.Cells["Id3"].Value.ToString();

            //var fm = (MainForm)this.Owner;
            //fm.TerminalModel = MainForm.TerminalModelList.Where(p => p.Id == int.Parse(Id1)).FirstOrDefault();

            //this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void dgv_data4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //var Id1 = dgv_data4.CurrentRow.Cells["Id4"].Value.ToString();

            //var fm = (MainForm)this.Owner;
            //fm.TerminalModel = TerminalModelList.Where(p => p.Id == int.Parse(Id1)).FirstOrDefault();

            //this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void dgv_data5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //var Id1 = dgv_data5.CurrentRow.Cells["Id5"].Value.ToString();

            //var fm = (MainForm)this.Owner;
            //fm.TerminalModel = TerminalModelList.Where(p => p.Id == int.Parse(Id1)).FirstOrDefault();

            //this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void button_Click(object sender, EventArgs e)
        {
            var zf = (sender as Button).Text;
            Initial += zf;
            txtzf.Text = Initial;
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            Initial = "";
            txtzf.Text = Initial;

            DataBind_dgv_data();
        }

        private void textzf_TextChanged(object sender, EventArgs e)
        {
            Initial = txtzf.Text.Trim();
            DataBind_dgv_data();
        }

        private void dgv_Initials_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Initial = dgv_Initials.CurrentRow.Cells["Initials"].Value.ToString();

            txtzf.Text = Initial;

            DataBind_dgv_data();
        }

        private void cbxManufactor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBind_dgv_data();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            int WM_KEYDOWN = 256;
            int WM_SYSKEYDOWN = 260;
            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Escape:
                        this.Close();//esc关闭窗体
                        break;
                }
            }
            return false;
        }
    }
}
