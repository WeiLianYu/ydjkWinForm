namespace 移动家客WinApp.Model.Input.Fx
{
    public class Add_FxTerminalAccountDto
    {
        /// <summary>
        /// 包装箱ID
        /// </summary>
        public string FX_BoxID { get; set; }

        /// <summary>
        /// 批次号，送检收货时填写
        /// </summary>
        public string BatchNum { get; set; }

        /// <summary>
        /// 物流单号
        /// </summary>
        public string LogisticsNum { get; set; }

        /// <summary>
        /// 地市
        /// </summary>
        public int? areaid1 { get; set; }

        /// <summary>
        /// 区县
        /// </summary>
        public int? areaid2 { get; set; }

        /// <summary>
        /// 终端类型
        /// </summary>
        public int? TerminalType { get; set; }

        /// <summary>
        /// 厂家
        /// </summary>
        public int? Manufactor { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public int? TerminalModel { get; set; }

        /// <summary>
        /// S/N码
        /// </summary>
        public string SNNum { get; set; }

        /// <summary>
        /// 终端状态(好件, 返厂, 报废)
        /// </summary>
        public int? TerminalState { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 清洗人
        /// </summary>
        public string Cleaner { get; set; }

        /// <summary>
        /// SN匹配来源
        /// </summary>
        public string Match { get; set; }

        /// <summary>
        /// 物流单ID
        /// </summary>
        public string LogisticsId { get; set; }
    }

    public class SealingBoxDto
    {
        public string snnum { get; set; }
        public string FX_BoxID { get; set; }
        public string Cleaner { get; set; }
        //public string LogisticsId { get; set; }
    }
}