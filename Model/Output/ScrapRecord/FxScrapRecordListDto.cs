using System;
using System.Collections.Generic;

namespace 移动家客WinApp.Model.Output.ScrapRecord
{
    public class FxScrapRecordListDto
    {
        public List<FxScrapRecordDto> list { get; set; }

        public int total { get; set; }
    }

    public class FxScrapRecordDto
    {
        public string Id { get; set; }

        /// <summary>
        /// 地市
        /// </summary>
        public int? areaid1 { get; set; }

        public string AreaName1 { get; set; }

        /// <summary>
        /// 区县
        /// </summary>
        public int? areaid2 { get; set; }

        public string AreaName2 { get; set; }

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
        /// 状态
        /// </summary>
        public int? TerminalState { get; set; }

        public string TerminalStateName { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int? State { get; set; }

        public string createuserid { get; set; }

        public string realityname { get; set; }

        public DateTime? createtime { get; set; }
    }
}