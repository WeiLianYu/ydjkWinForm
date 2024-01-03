namespace 移动家客WinApp.Model.Input.Fx
{
    public class GetList_FxBoxDto
    {
        public int pageindex { get; set; } = 1;

        public int pagesize { get; set; } = 20;

        /// <summary>
        /// 批次号
        /// </summary>
        public string BatchNum { get; set; }

        /// <summary>
        /// 区县
        /// </summary>
        public int AreaId2 { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string createuserid { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public int? usertype { get; set; }
    }
}