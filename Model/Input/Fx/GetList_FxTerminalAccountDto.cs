namespace 移动家客WinApp.Model.Input.Fx
{
    public class GetList_FxTerminalAccountDto
    {
        public int pageindex { get; set; } = 1;

        public int pagesize { get; set; } = 20;

        /// <summary>
        /// 封箱号
        /// </summary>
        public string boxnum { get; set; }

        /// <summary>
        /// 封箱ID
        /// </summary>
        public string boxId { get; set; }
    }
    public class Get_FxTerminalAccountDto
    {
        /// <summary>
        /// 物流单号
        /// </summary>
        public string LogisticsId { get; set; }

        /// <summary>
        /// SN码
        /// </summary>
        public string SNNum { get; set; }
    }
}