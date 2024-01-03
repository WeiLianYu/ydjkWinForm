using System.Configuration;

namespace 移动家客WinApp.Business.Service
{
    internal class BaseService
    {
        public static readonly string BaseAddress;
        public static string token = string.Empty;
        public static string UserId = string.Empty;

        static BaseService()
        {
            BaseAddress = ConfigurationManager.AppSettings["BaseAddress"];
        }

        public static string GetApiUrl(string ActionUlr)
        {
            return $"{BaseAddress}{ActionUlr}";
        }
    }
}