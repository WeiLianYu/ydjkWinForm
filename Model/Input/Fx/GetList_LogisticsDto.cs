namespace 移动家客WinApp.Model.Input.Fx
{
    public class GetList_LogisticsDto
    {
        public int page { get; set; } = 1;

        public int pagesize { get; set; } = 20;

        /// <summary>
        /// 未封箱
        /// </summary>
        public int? winformSearch { get; set; }

        /// <summary>
        /// 物流单状态(1：待处理，2：完成)
        /// </summary>
        public int? logisticsstate { get; set; }

        public string BatchNum { get; set; }

        /// <summary>
        /// 运输状态
        /// </summary>
        public int? deliverystatus { get; set; }
    }
}