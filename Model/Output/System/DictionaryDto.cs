using System.Collections.Generic;

namespace 移动家客WinApp.Model.Output.System
{
    public class DictionaryDto
    {
        public List<DictionaryInfo> list { get; set; }
        public int total { get; set; }
    }

    public class DictionaryInfo
    {
        public string text { get; set; }
        public int value { get; set; }
    }
}