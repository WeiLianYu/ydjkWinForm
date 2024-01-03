using System;

namespace 移动家客WinApp.Model.Input.Fx
{
    public class Add_FxLogisticsDto
    {
        public string BatchNum { get; set; }
        public int? areaid1 { get; set; }
        public int? areaid2 { get; set; }
        public string logisticsnum { get; set; }
        public string logisticsuser { get; set; }
        public string logisticsmobile { get; set; }
        public int? sendboxcount { get; set; }
        public int? sendcount { get; set; }
        public int? receiveboxcount { get; set; }
        public int? receivecount { get; set; }
        public string shipments { get; set; }
        public int? sortcount { get; set; }
        public int? weight { get; set; }
        public string remark { get; set; }
        public DateTime? createtime { get; set; }
    }
}