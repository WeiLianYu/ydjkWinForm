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
using 移动家客WinApp.Model.Input.Fx;
using 移动家客WinApp.Model.Input.Terminal;
using 移动家客WinApp.Model.Output;
using 移动家客WinApp.Model.Output.Fx;
using 移动家客WinApp.Model.Output.System;
using 移动家客WinApp.Model.Output.Terminal;

namespace 移动家客WinApp
{
    public partial class SealingBoxAdd : Form
    {
        private readonly IFxBoxService _FxBox;
        private readonly IAreaService _Area;
        private readonly IDictionaryService _Dictionary;
        private readonly ITerminalModelService _TerminalModel;
        private readonly IFxLogisticsService _FxLogistics;
        private Form parentForm;

        public SealingBoxAdd(Form _parentForm)
        {
            InitializeComponent();
            parentForm = _parentForm;
            
            _FxBox = new FxBoxService();
            _Area = new AreaService();
            _Dictionary = new DictionaryService();
            _TerminalModel = new TerminalModelService();
            _FxLogistics = new FxLogisticsService();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void SealingBoxAdd_Load(object sender, EventArgs e)
        {
            //parentForm.Visible = false;

            //txtFX_Box_Num.Text = _FxBox.GenerateBoxNum();
            //txtFX_Logistics_BatchNum.Text = _FxBox.GenerateBatchNum();
            dateTimePicker1.MaxDate = DateTime.Now.AddDays(1);
            dateTimePicker1.MinDate = DateTime.Now.AddYears(-1);
            BingData();
        }

        private async void BingData() {
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

            //DictionaryDto Manufactors = new DictionaryDto();
            //try
            //{
            //    Manufactors = await _Dictionary.GetList("Manufactor");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //cbxManufactor.DataSource = Manufactors.list;
            //cbxManufactor.DisplayMember = "text";
            //cbxManufactor.ValueMember = "value";
            //if (cbxManufactor.Items.Count > 0)
            //{
            //    cbxManufactor.SelectedIndex = 0;
            //}

            //DictionaryDto TerminalTypes = new DictionaryDto();
            //try
            //{
            //    TerminalTypes = await _Dictionary.GetList("TerminalType");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //cbxTerminalType.DataSource = TerminalTypes.list;
            //cbxTerminalType.DisplayMember = "text";
            //cbxTerminalType.ValueMember = "value";
            //cbxTerminalType.SelectedIndex = 0;
            //if (cbxTerminalType.Items.Count > 0)
            //{
            //    cbxTerminalType.SelectedIndex = 0;
            //}


            //DictionaryDto Dictionarys = new DictionaryDto();
            //try
            //{
            //    Dictionarys = await _Dictionary.GetList("SortType");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //cbxSortType.DataSource = Dictionarys.list;
            //cbxSortType.DisplayMember = "text";
            //cbxSortType.ValueMember = "value";
            //cbxSortType.SelectedIndex = 0;
            //if (cbxSortType.Items.Count > 0)
            //{
            //    cbxSortType.SelectedIndex = 0;
            //}

            //var model = new GetList_TerminalModelDto
            //{
            //    //manufactor = (int)cbxManufactor.SelectedValue,
            //    //terminaltype = (int)cbxTerminalType.SelectedValue
            //};

            //TerminalModelDto TerminalModelList = new TerminalModelDto();
            //try
            //{
            //    TerminalModelList = await _TerminalModel.GetList(model);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //cbxTerminalModel.DataSource = TerminalModelList.list;
            //cbxTerminalModel.ValueMember = "Id";
            //cbxTerminalModel.DisplayMember = "Model";
            //if (cbxTerminalModel.Items.Count > 0)
            //{
            //    cbxTerminalModel.SelectedIndex = 0;
            //}
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                await AddBox();
            } 
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Cancel;
                MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //var area1 = 0;
            //if (cbxarea1.SelectedValue == null || !int.TryParse(cbxarea1.SelectedValue.ToString(), out area1))
            //{
            //    MessageBox.Show($"请选择地市!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //var area2 = 0;
            //if (cbxarea2.SelectedValue == null || !int.TryParse(cbxarea2.SelectedValue.ToString(), out area2))
            //{
            //    MessageBox.Show($"请选择区县!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //var TerminalTypeID = 0;
            //if (cbxTerminalType.SelectedValue == null || !int.TryParse(cbxTerminalType.SelectedValue.ToString(), out TerminalTypeID))
            //{
            //    MessageBox.Show($"请选择终端类型!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //var ManufactorId = 0;
            //if (cbxManufactor.SelectedValue == null || !int.TryParse(cbxManufactor.SelectedValue.ToString(), out ManufactorId))
            //{
            //    MessageBox.Show($"请选择终端厂家!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //var TerminalModelId = 0;
            //if (cbxTerminalModel.SelectedValue == null || !int.TryParse(cbxTerminalModel.SelectedValue.ToString(), out TerminalModelId))
            //{
            //    MessageBox.Show($"请选择终端型号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //var SortTypeId = 0;
            //if (cbxSortType.SelectedValue == null || !int.TryParse(cbxSortType.SelectedValue.ToString(), out SortTypeId))
            //{
            //    MessageBox.Show($"请选择终端状态!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //var model = new Add_FxBoxDto
            //{
            //    BatchNum = txtFX_Logistics_BatchNum.Text.Trim(),
            //    LogisticsNum = txtFX_Logistics_LogisticsNum.Text.Trim(),
            //    //Logistictime = Fx_Logistics.CreateTime,
            //    areaid1 = area1,
            //    areaid2 = area2,
            //    TerminalType = TerminalTypeID,
            //    Manufactor = ManufactorId,
            //    TerminalModel = TerminalModelId,
            //    SortType = SortTypeId,
            //    Remark = txtRemark.Text.Trim(),
            //    TerminalCount = 1
            //};

            //try
            //{
            //   await _FxBox.Add(model);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //MessageBox.Show($"添加完成!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //this.Close();
        }

        private async Task AddBox()
        {
            var DataTime = dateTimePicker1.Text.Trim();
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

            try
            {
                Add_FxLogisticsDto model = new Add_FxLogisticsDto();
                model.areaid1 = area1;
                model.areaid2 = area2;
                model.logisticsnum = area1.ToString() + area2.ToString() + DateTime.Parse(DataTime).ToString("yyyyMMdd") + "001"; 
                model.BatchNum = cbxarea1.Text + cbxarea2.Text + DateTime.Parse(DataTime).ToString("yyyyMMdd") + "001";

                FxLogisticsDto Fx_Logistics = null;
                try
                {
                     Fx_Logistics = await _FxLogistics.Add(model);
                }
                catch (Exception ex)
                {
                    throw ex;
                }                

                var fm = (MainForm)this.Owner;
                fm.GetValue(new Tuple<string, string>(DataTime, cbxarea2.Text));

                //fm.Fx_Logistics = Fx_Logistics;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //parentForm.Visible = true;
            this.Close();
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

        private void SealingBoxAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm.Visible = true;
        }

        private async void cbxTerminalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Manufactorid = -1;
            var Dictionary = cbxManufactor.SelectedValue as DictionaryInfo;
            if (Dictionary != null)
            {
                Manufactorid = Dictionary.value;
            }
            else
            {
                if (cbxManufactor.Items.Count > 0)
                {
                    Manufactorid = (int)cbxManufactor.SelectedValue;
                }
                
            }

            int TerminalTypeid = -1;
            Dictionary = cbxTerminalType.SelectedValue as DictionaryInfo;
            if (Dictionary != null)
            {
                TerminalTypeid = Dictionary.value;
            }
            else
            {
                if (cbxTerminalType.Items.Count > 0)
                {
                    TerminalTypeid = (int)cbxTerminalType.SelectedValue;
                }
                
            }

            var model = new GetList_TerminalModelDto
            {
                //manufactor = Manufactorid,
                //terminaltype = TerminalTypeid
            };

            TerminalModelDto TerminalModelList = new TerminalModelDto();
            try
            {
                TerminalModelList = await _TerminalModel.GetList(model);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cbxTerminalModel.DataSource = TerminalModelList.list;
            cbxTerminalModel.ValueMember = "Id";
            cbxTerminalModel.DisplayMember = "Model";
            if (cbxTerminalModel.Items.Count > 0)
            {
                cbxTerminalModel.SelectedIndex = 0;
            }
        }

        private async void cbxManufactor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Manufactorid = -1;
            var Dictionary = cbxManufactor.SelectedValue as DictionaryInfo;
            if (Dictionary != null)
            {
                Manufactorid = Dictionary.value;
            }
            else
            {
                if (cbxManufactor.Items.Count > 0)
                {
                    Manufactorid = (int)cbxManufactor.SelectedValue;
                }
            }

            int TerminalTypeid = -1;
            Dictionary = cbxTerminalType.SelectedValue as DictionaryInfo;
            if (Dictionary != null)
            {
                TerminalTypeid = Dictionary.value;
            }
            else
            {
                if (cbxTerminalType.Items.Count > 0)
                {
                    TerminalTypeid = (int)cbxTerminalType.SelectedValue;
                }
            }

            var model = new GetList_TerminalModelDto
            {
                //manufactor = Manufactorid,
                //terminaltype = TerminalTypeid
            };

            TerminalModelDto TerminalModelList = new TerminalModelDto();
            try
            {
                TerminalModelList = await _TerminalModel.GetList(model);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cbxTerminalModel.DataSource = TerminalModelList.list;
            cbxTerminalModel.ValueMember = "Id";
            cbxTerminalModel.DisplayMember = "Model";
            if (cbxTerminalModel.Items.Count > 0)
            {
                cbxTerminalModel.SelectedIndex = 0;
            }
        }
    }
}
