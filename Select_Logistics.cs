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
using 移动家客WinApp.Comm;
using 移动家客WinApp.Model.Input.Fx;
using 移动家客WinApp.Model.Output.Fx;

namespace 移动家客WinApp
{
    public partial class Select_Logistics : Form
    {
        private int? sx_totalCount = 0;//总数据个数
        private int? sx_pageCount = 0;//总页数
        private int sx_pagesizeCount = 20;//每页显示数
        private int sx_currentPageIndex = 1;//当前页索引

        private FxLogisticsDto Fx_Logistics;

        private readonly IFxLogisticsService FxLogistics;

        public Select_Logistics()
        {
            InitializeComponent();
            FxLogistics = new FxLogisticsService();
            label16.Text = sx_pagesizeCount.ToString();
        }

        private void Select_Logistics_Load(object sender, EventArgs e)
        {
            DataGridViewBind();

            AddDataGridViewColumn();
        }

        private async void DataGridViewBind()
        {
            //行高自适应
            dgv_Logistics.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgv_Logistics.AutoGenerateColumns = false;

            var model = new GetList_LogisticsDto
            {
                page = sx_currentPageIndex,
                pagesize = sx_pagesizeCount,
                winformSearch = 1,
                BatchNum = txtBatchNum.Text.Trim(),
                deliverystatus = 2
            };

            FxLogisticsListDto query = new FxLogisticsListDto();
            try
            {
                query = await FxLogistics.GetList(model);
                this.dgv_Logistics.DataSource = query.list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //一共多少条数据
            sx_totalCount = query.total;
            label12.Text = sx_totalCount.ToString();
            //页数
            var remainder = query.total % sx_pagesizeCount;
            if (remainder > 0)
            {
                sx_pageCount = ((query.total / sx_pagesizeCount) + 1);
                label10.Text = sx_pageCount.ToString();
            }
            else
            {
                sx_pageCount = (query.total / sx_pagesizeCount);
                label10.Text = sx_pageCount.ToString();
            }
            //当前页数
            textBox2.Text = sx_currentPageIndex.ToString();
        }

        //private void butSave_Click(object sender, EventArgs e)
        //{
        //    if (this.txtDataTime.Text.Trim() == "" || this.txtArea.Text.Trim() == "")
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        var fm = (MainForm)this.Owner;
        //        fm.GetValue(new Tuple<string, string>(this.txtDataTime.Text.Trim(), this.txtArea.Text.Trim()));

        //        fm.Fx_Logistics = Fx_Logistics;
        //        this.Close();
        //    }
        //}

        private void AddDataGridViewColumn()
        {
            //为dgv增加一列按钮
            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.Name = "BtnSelect";    //设置列的名称
            btn1.Text = "选择";     //按钮上的文字属性
            btn1.DefaultCellStyle.NullValue = "选择";
            btn1.HeaderText = "操作";     //显示的列名
            //btn1.Width = 50;
            this.dgv_Logistics.Columns.Insert(0, btn1); //在dataGridView1的最后一列添加按钮
            this.dgv_Logistics.Columns[0].Width = 60;
        }

        /// <summary>
        /// 列表显示序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Logistics_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //序号
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
               e.RowBounds.Location.Y,
               dgv_Logistics.RowHeadersWidth - 4,
               e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgv_Logistics.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgv_Logistics.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private async void dgv_Logistics_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //点击第一行button按钮事件
            if (dgv_Logistics.Columns[e.ColumnIndex].Name == "BtnSelect")
            {
                var Id = dgv_Logistics.CurrentRow.Cells["Id"].Value.ToString();

                var DataTime = dgv_Logistics.CurrentRow.Cells["CreateTime"].Value.ToString();
                var Area = dgv_Logistics.CurrentRow.Cells["AreaName"].Value.ToString();

                try
                {
                    Fx_Logistics = await FxLogistics.GetInfo(Id);

                    var fm = (MainForm)this.Owner;
                    fm.GetValue(new Tuple<string, string>(DataTime, Area));

                    //fm.Fx_Logistics = Fx_Logistics;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewBind();
        }
    }
}
