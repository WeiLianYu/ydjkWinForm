using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 移动家客WinApp.Model;

namespace 移动家客WinApp.Comm
{
    public interface IPrintBase
    {
        void TerminalPrint(string areaname, string username, string manufactor, string model, string type, string Usually, string barCode, string num, DateTime time, string openport);

        void BoxsPrint(int i, string areaname, List<ModelGroup> list, int SortCount, string Num, string username, DateTime time, string openport);
    }
}
