using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using 移动家客WinApp.Business.IService;
using 移动家客WinApp.Comm;
using 移动家客WinApp.Model.Input.Fx;
using 移动家客WinApp.Model.Output.Fx;

namespace 移动家客WinApp.Business.Service
{
    internal class FxLogisticsService : BaseService, IFxLogisticsService
    {
        //获取终端型号列表
        private static readonly string api_GetLogisticsList = GetApiUrl("TerminalModel/Logistics/GetLogisticsList");

        private static readonly string api_GetLogisticsInfo = GetApiUrl("TerminalModel/Logistics/GetLogisticsInfo");
        private static readonly string api_AddLogistics = GetApiUrl("TerminalModel/Logistics/AddLogistics");

        public FxLogisticsService()
        {
        }

        public async Task<FxLogisticsDto> Add(Add_FxLogisticsDto model)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }

            var api_Data_Token = await HttpWebRequestHelper.HttpApi<FxLogisticsDto>(api_AddLogistics, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data_Token?.error ?? false))
            {
                throw new Exception(api_Data_Token.errormessage);
            }
            return api_Data_Token.data;
        }

        public async Task<FxLogisticsDto> GetInfo(string Id)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }

            var model = new
            {
                Id = Id
            };
            var api_Data = await HttpWebRequestHelper.HttpApi<FxLogisticsDto>(api_GetLogisticsInfo, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data?.error ?? false))
            {
                throw new Exception(api_Data.errormessage);
            }
            return api_Data.data;
        }

        public async Task<FxLogisticsListDto> GetList(GetList_LogisticsDto model)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }

            var api_Data = await HttpWebRequestHelper.HttpApi<FxLogisticsListDto>(api_GetLogisticsList, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data?.error ?? false))
            {
                throw new Exception(api_Data.errormessage);
            }
            return api_Data.data;
        }
    }
}