using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using 移动家客WinApp.Business.IService;
using 移动家客WinApp.Comm;
using 移动家客WinApp.Model.Input.Terminal;
using 移动家客WinApp.Model.Output.Terminal;

namespace 移动家客WinApp.Business.Service
{
    internal class TerminalModelService : BaseService, ITerminalModelService
    {
        //获取终端型号列表
        private static readonly string api_GetModelList = GetApiUrl("TerminalModel/TerminalModel/GetModelList");

        private static readonly string api_GetModelInfo = GetApiUrl("TerminalModel/TerminalModel/GetModelInfo");

        public TerminalModelService()
        {
        }

        public async Task<TerminalModelDto> GetList(GetList_TerminalModelDto model)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }

            var api_Data = await HttpWebRequestHelper.HttpApi<TerminalModelDto>(api_GetModelList, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data?.error ?? false))
            {
                throw new Exception(api_Data.errormessage);
            }
            return api_Data.data;
        }

        public async Task<TerminalModelInfo> GetInfo(int Id)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }
            var model = new
            {
                id = Id
            };
            var api_Data = await HttpWebRequestHelper.HttpApi<TerminalModelInfo>(api_GetModelInfo, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data?.error ?? false))
            {
                throw new Exception(api_Data.errormessage);
            }
            if (api_Data?.data?.AccessType.HasValue ?? false)
            {
                if (api_Data?.data?.AccessType.Value == 1)
                {
                    api_Data.data.AccessTypeName = "EPON";
                }
                else if (api_Data?.data?.AccessType.Value == 2)
                {
                    api_Data.data.AccessTypeName = "GPON";
                }
            }
            return api_Data.data;
        }
    }
}