namespace 移动家客WinApp.Model.Input.QR
{
    public class GetInfo_QRDto
    {
        public int page { get; set; } = 1;

        public int pagesize { get; set; } = 1000;

        public int modelid { get; set; }
    }

    public class GetContrastInfoDto
    {
        public string snnum { get; set; }
    }
}