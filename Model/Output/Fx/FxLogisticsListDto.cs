using System;
using System.Collections.Generic;

namespace 移动家客WinApp.Model.Output.Fx
{
    public class FxLogisticsListDto
    {
        public List<FxLogisticsDto> list { get; set; }

        public int total { get; set; }
    }

    public class FxLogisticsDto
    {
        public string Id { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public string BatchNum { get; set; }

        /// <summary>
        /// 物流单号
        /// </summary>
        public string LogisticsNum { get; set; }

        /// <summary>
        /// 物流联系人
        /// </summary>
        public string LogisticsUser { get; set; }

        /// <summary>
        /// 物流电话
        /// </summary>
        public string LogisticsMobile { get; set; }

        /// <summary>
        /// 地区ID
        /// </summary>
        public int? Areaid1 { get; set; }

        /// <summary>
        /// 地区名称
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 区县ID
        /// </summary>
        public int? Areaid2 { get; set; }

        /// <summary>
        /// 区县名称
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 发货方
        /// </summary>
        public string Shipments { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// 终端箱数(收货)
        /// </summary>
        public int? ReceiveBoxCount { get; set; }

        /// <summary>
        /// 终端数量(收货)
        /// </summary>
        public int? ReceiveCount { get; set; }

        /// <summary>
        /// 分拣数据
        /// </summary>
        public int? SortCount { get; set; }

        public int? ProblemCount { get; set; }

        /// <summary>
        /// 未分拣
        /// </summary>
        public int? Count { get; set; }
    }
}