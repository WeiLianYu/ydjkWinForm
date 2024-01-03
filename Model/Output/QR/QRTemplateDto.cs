using System;
using System.Collections.Generic;

namespace 移动家客WinApp.Model.Output.QR
{
    public class QRTemplateDto
    {
        public List<QRTemplateInfo> list { get; set; }
        public int total { get; set; }
    }

    public class QRTemplateInfo
    {
        public string Id { get; set; }
        public string TemplateNum { get; set; }
        public int? TerminalType { get; set; }
        public int? TerminalModel { get; set; }
        public int? Manufactor { get; set; }
        public string QRCodeType { get; set; }
        public int? Length { get; set; }
        public string FirstCharacter { get; set; }
        public string createuserid { get; set; }
        public DateTime? createtime { get; set; }
    }

    public class ContrastInfo
    {
        public int id { get; set; }
        public string snnum { get; set; }
        public int? modelid { get; set; }
        public string model { get; set; }
        public string manufactor { get; set; }
        public string terminaltype { get; set; }
        public DateTime? date { get; set; }
        public string terminalrecovery { get; set; }
        public string terminalstate { get; set; }
    }
}