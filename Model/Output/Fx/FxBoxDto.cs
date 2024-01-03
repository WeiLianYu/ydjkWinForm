using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 移动家客WinApp.Model.Output.Fx
{
    public class FxBoxDto
    {
        public string Id { get; set; }

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
        public string AreaName1 { get; set; }

        /// <summary>
        /// 区县
        /// </summary>
        public int areaid2 { get; set; }

        public string AreaName2 { get; set; }

        /// <summary>
        /// 终端类型
        /// </summary>
        public int TerminalType { get; set; }

        public string TerminalTypeName { get; set; }

        /// <summary>
        /// 厂家
        /// </summary>
        public int Manufactor { get; set; }

        public string ManufactorName { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public int TerminalModel { get; set; }

        public string TerminalModelName { get; set; }

        /// <summary>
        /// 终端状态(1.好件   2.报废    3.返厂)
        /// </summary>
        public int SortType { get; set; }

        public string SortTypeName { get; set; }

        /// <summary>
        /// 终端数量
        /// </summary>
        public int TerminalCount { get; set; }

        /// <summary>
        /// 包装箱状态 (1.新建 2.封箱)
        /// </summary>
        public int BoxState { get; set; }

        public string BoxStateName { get; set; }

        /// <summary>
        /// 封箱人
        /// </summary>
        public string CloseBoxuserid { get; set; }

        public string CloseBoxUser { get; set; }

        /// <summary>
        /// 封箱时间
        /// </summary>
        public DateTime? CloseBoxtime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 数据状态
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string createuserid { get; set; }

        public string CreateUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? createtime { get; set; }

        /// <summary>
        /// 物流单创建时间
        /// </summary>
        public DateTime? Logistictime { get; set; }
    }
}
