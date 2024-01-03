namespace 移动家客WinApp.Model.Output
{
    public class BaseDto<T>
    {
        public string responsetimestamp { get; set; }
        public bool error { get; set; }
        public string traceid { get; set; }
        public string errorcode { get; set; }
        public string errormessage { get; set; }
        public T data { get; set; }
    }
}