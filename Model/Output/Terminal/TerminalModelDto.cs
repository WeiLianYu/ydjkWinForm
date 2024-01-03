using System.Collections.Generic;

namespace 移动家客WinApp.Model.Output.Terminal
{
    public class TerminalModelDto
    {
        public List<TerminalModelInfo> list { get; set; }
        public int total { get; set; }
    }

    public class TerminalModelInfo
    {
        public int Id { get; set; }

        public string model { get; set; }

        public int? manufactor { get; set; }

        public string manufactorname { get; set; }

        public int? terminaltype { get; set; }

        public string terminaltypename { get; set; }

        public string Adapter { get; set; }

        public int? AccessType { get; set; }

        public string AccessTypeName { get; set; }

        public int? Length { get; set; }

        public string FirstCharacter { get; set; }
    }
}