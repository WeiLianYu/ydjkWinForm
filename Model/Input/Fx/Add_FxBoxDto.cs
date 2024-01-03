using System;

namespace 移动家客WinApp.Model.Input.Fx
{
    public class Add_FxBoxDto
    {
        /// <summary>
        /// 批次号，送检收货时填写
        /// </summary>
        public string BatchNum { get; set; }

        /// <summary>
        /// 物流单号
        /// </summary>
        public string LogisticsNum { get; set; }

        /// <summary>
        /// 包装箱编码
        /// </summary>
        public string Num { get; set; }

        /// <summary>
        /// 地市
        /// </summary>
        public int areaid1 { get; set; }

        /// <summary>
        /// 区县
        /// </summary>
        public int areaid2 { get; set; }

        /// <summary>
        /// 终端类型
        /// </summary>
        public int TerminalType { get; set; }

        /// <summary>
        /// 厂家
        /// </summary>
        public int Manufactor { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public int TerminalModel { get; set; }

        /// <summary>
        /// 终端状态(1.好件   2.报废    3.返厂)
        /// </summary>
        public int SortType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 终端数量
        /// </summary>
        public int? TerminalCount { get; set; }

        /// <summary>
        /// 物流单创建时间
        /// </summary>
        public DateTime? Logistictime { get; set; }

        /// <summary>
        /// 物流单ID
        /// </summary>
        public string LogisticsId { get; set; }
    }
}