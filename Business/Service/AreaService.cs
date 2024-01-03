using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using 移动家客WinApp.Business.IService;
using 移动家客WinApp.Comm;
using 移动家客WinApp.Model.Output.System;

namespace 移动家客WinApp.Business.Service
{
    internal class AreaService : BaseService, IAreaService
    {
        //查询区域列表
        private static readonly string api_GetAreaListAsync = GetApiUrl("Admin/Area/GetAreaListAsync");

        public AreaService()
        {
        }

        public async Task<List<AreaDto>> GetList(string parentId = "420000")
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }
            var model = new
            {
                parentid = parentId
            };
            var api_Data = await HttpWebRequestHelper.HttpApi<List<AreaDto>>(api_GetAreaListAsync, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data?.error ?? false))
            {
                throw new Exception(api_Data.errormessage);
            }
            return api_Data.data;
        }
    }
}