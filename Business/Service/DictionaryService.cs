using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using 移动家客WinApp.Business.IService;
using 移动家客WinApp.Comm;
using 移动家客WinApp.Model.Output.System;

namespace 移动家客WinApp.Business.Service
{
    internal class DictionaryService : BaseService, IDictionaryService
    {
        //查询区域列表
        //private static readonly string api_GetDictionaryInfoList = GetApiUrl("Admin/Dictionary/GetDictionaryInfoList");
        private static readonly string api_GetDictionarylist = GetApiUrl("Admin/Dictionary/GetDictionarylist");

        public DictionaryService()
        {
        }

        public async Task<DictionaryDto> GetList(string type)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }
            var model = new
            {
                page = 1,
                pagesize = 1000,
                type = type
            };
            var api_Data = await HttpWebRequestHelper.HttpApi<DictionaryDto>(api_GetDictionarylist, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data?.error ?? false))
            {
                throw new Exception(api_Data.errormessage);
            }
            return api_Data.data;
        }
    }
}