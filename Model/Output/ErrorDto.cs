namespace 移动家客WinApp.Model.Output
{
    public class ErrorDto
    {
        public string responsetimestamp { get; set; }
        public bool error { get; set; }
        public string traceid { get; set; }
        public string errorcode { get; set; }
        public string errormessage { get; set; }
    }
}