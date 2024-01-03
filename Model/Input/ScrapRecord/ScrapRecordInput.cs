using System;

namespace 移动家客WinApp.Model.Input.ScrapRecord
{
    public class GetScrapRecordListInput
    {
        public int? page { get; set; }

        public int? pageSize { get; set; }

        public DateTime? CreateStartTime { get; set; }

        public DateTime? CreateEndTime { get; set; }
    }

    public class AddScrapRecordInput
    {
        public string snnum { get; set; }
        public int? areaid1 { get; set; }
        public int? areaid2 { get; set; }
    }

    public class EditScrapRecordInput
    {
        public string id { get; set; }

        public string snnum { get; set; }
    }
}