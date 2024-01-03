using System.Collections.Generic;

namespace 移动家客WinApp.Model
{
    public class TerminalModelGroup
    {
        public List<ManufactorName> ManufactorNames { get; set; }
    }

    public class ManufactorName
    {
        public List<ModelGroup> TerminalModelList { get; set; }
    }

    public class ModelGroup
    {
        public string ManufactorName { get; set; }

        public string TerminalModelName { get; set; }
        public int Count { get; set; }
    }

    public class TerminalModelGroupInfo
    {
        public string ManufactorName { get; set; }
        public string TerminalModelName { get; set; }
        public int Count { get; set; }
    }

    public class TerminalModelGroupList
    {
        public List<TerminalModelGroupInfo> terminalModelGroupList { get; set; }
    }
}