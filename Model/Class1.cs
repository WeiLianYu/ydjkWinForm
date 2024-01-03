using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 移动家客WinApp.Model
{
    public class TerminalModelGroup
    {
        public List<ModelGroup> TerminalModelList { get; set; }
    }

    public class ModelGroup
    {
        public string ManufactorName { get; set; }

        public string TerminalModelName { get; set; }
        public int Count { get; set; }
    }
}