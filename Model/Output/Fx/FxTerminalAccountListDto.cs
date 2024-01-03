﻿using System;
using System.Collections.Generic;

namespace 移动家客WinApp.Model.Output.Fx
{
    public class FxTerminalAccountListDto
    {
        public List<FxTerminalAccountDto> list { get; set; }

        public int total { get; set; }
    }

    public class FxTerminalAccountDto
    {
        public string Id { get; set; }

        public string Num { get; set; }

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

        public string TerminalTypeName { get; set; }

        /// <summary>
        /// 厂家
        /// </summary>
        public int? Manufactor { get; set; }

        public string ManufactorName { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public int? TerminalModel { get; set; }

        public string TerminalModelName { get; set; }

        /// <summary>
        /// S/N码
        /// </summary>
        public string SNNum { get; set; }

        /// <summary>
        /// 终端状态(好件, 返厂, 报废)
        /// </summary>
        public int? TerminalState { get; set; }

        public string TerminalStateName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 包装箱ID
        /// </summary>
        public string FX_BoxID { get; set; }

        public string BoxNum { get; set; }

        public string CreateUser { get; set; }

        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 清洗人
        /// </summary>
        public string Cleaner { get; set; }
    }
}