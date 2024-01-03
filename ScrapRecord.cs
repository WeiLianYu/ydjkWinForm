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
using 移动家客WinApp.Model.Input.ScrapRecord;
using 移动家客WinApp.Model.Output.Fx;
using 移动家客WinApp.Model.Output.ScrapRecord;
using 移动家客WinApp.Model.Output.System;

namespace 移动家客WinApp
{
    public partial class ScrapRecord : Form
    {

        //包装箱号
        private string fxBoxId = string.Empty;
        private Form parentForm;
        private IFxScrapRecordService fxScrapRecord;
        private readonly IAreaService _Area;

        private void ScrapRecord_Load(object sender, EventArgs e)
        {
            BingData();
        }

        public ScrapRecord(Form _parentForm)
        {
            InitializeComponent();
            this.parentForm = _parentForm;

            fxScrapRecord = new FxScrapRecordService();
            _Area = new AreaService();

            DataGridViewBind();
            AddDataGridViewColumn();
        }

        private async void BingData()
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

        private async void DataGridViewBind()
        {
            ////行高自适应
            dgvScrapRecord.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvScrapRecord.AutoGenerateColumns = false;
            dgvScrapRecord.Font = new Font("微软雅黑", 15);
            var model = new GetScrapRecordListInput
            {
                page = 1,
                pageSize = 20                 
            };

            FxScrapRecordListDto query = new FxScrapRecordListDto();
            try
            {
                query = await fxScrapRecord.GetList(model);
                dgvScrapRecord.DataSource = query.list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void AddDataGridViewColumn()
        {
            //为dgv增加一列按钮
            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.Name = "BtnDel";    //设置列的名称
            btn1.Text = "删除";     //按钮上的文字属性
            btn1.DefaultCellStyle.NullValue = "删除";
            btn1.HeaderText = "操作";     //显示的列名
            //btn1.Width = 50;
            this.dgvScrapRecord.Columns.Insert(0, btn1); //在dataGridView1的最后一列添加按钮
            this.dgvScrapRecord.Columns[0].Width = 60;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
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

            var snnum = txtsn.Text.Trim();
            if (string.IsNullOrWhiteSpace(snnum))
            {
                snnum = Guid.NewGuid().ToString().Replace("-", "");
            }
            await fxScrapRecord.Add(new AddScrapRecordInput { snnum = snnum, areaid1 = area1, areaid2 = area2 });
            DataGridViewBind();
        }

        private async void dgvScrapRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //点击第一行button按钮事件
            if (dgvScrapRecord.Columns[e.ColumnIndex].Name == "BtnDel")
            {
                var snnum = dgvScrapRecord.CurrentRow.Cells["snnum"].Value.ToString();

                if (MessageBox.Show("SN:" + snnum + " 确认删除吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var Id = dgvScrapRecord.CurrentRow.Cells["Id"].Value.ToString();

                    try
                    {
                        await fxScrapRecord.Del(Id);
                        DataGridViewBind();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 显示列表序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvScrapRecord_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //序号
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
               e.RowBounds.Location.Y,
               dgvScrapRecord.RowHeadersWidth - 4,
               e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvScrapRecord.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvScrapRecord.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
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

        private void button3_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            var t = rd.Next(1, 999).ToString().PadLeft(3, '0');
            txtsn.Text = DateTime.Now.ToString("yyyyMMddhhmmss") + t;
        }
    }
}
