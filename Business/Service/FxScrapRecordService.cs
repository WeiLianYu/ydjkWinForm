using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using 移动家客WinApp.Business.IService;
using 移动家客WinApp.Comm;
using 移动家客WinApp.Model.Input.ScrapRecord;
using 移动家客WinApp.Model.Output.ScrapRecord;

namespace 移动家客WinApp.Business.Service
{
    internal class FxScrapRecordService : BaseService, IFxScrapRecordService
    {
        //获取终端型号列表
        private static readonly string api_GetList = GetApiUrl("ScrapRecord/ScrapRecord/GetList");

        private static readonly string api_GetModelInfo = GetApiUrl("ScrapRecord/ScrapRecord/GetModelInfo");
        private static readonly string api_AddModel = GetApiUrl("ScrapRecord/ScrapRecord/AddModel");
        private static readonly string api_EditModel = GetApiUrl("ScrapRecord/ScrapRecord/EditModel");
        private static readonly string api_DelModel = GetApiUrl("ScrapRecord/ScrapRecord/DelModel");

        public FxScrapRecordService()
        {
        }

        public async Task Add(AddScrapRecordInput model)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }

            var api_Data_Token = await HttpWebRequestHelper.HttpApi<string>(api_AddModel, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data_Token?.error ?? false))
            {
                throw new Exception(api_Data_Token.errormessage);
            }
        }

        public async Task<FxScrapRecordDto> GetInfo(string Id)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }

            var model = new
            {
                Id = Id
            };
            var api_Data = await HttpWebRequestHelper.HttpApi<FxScrapRecordDto>(api_GetModelInfo, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data?.error ?? false))
            {
                throw new Exception(api_Data.errormessage);
            }
            return api_Data.data;
        }

        public async Task Del(string Id)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }
            var model = new
            {
                Id = Id
            };
            var api_Data_Token = await HttpWebRequestHelper.HttpApi<string>(api_DelModel, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data_Token?.error ?? false))
            {
                throw new Exception(api_Data_Token.errormessage);
            }
        }

        public async Task Edit(EditScrapRecordInput model)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }
            var api_Data_Token = await HttpWebRequestHelper.HttpApi<string>(api_EditModel, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data_Token?.error ?? false))
            {
                throw new Exception(api_Data_Token.errormessage);
            }
        }

        public async Task<FxScrapRecordListDto> GetList(GetScrapRecordListInput model)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }

            var api_Data = await HttpWebRequestHelper.HttpApi<FxScrapRecordListDto>(api_GetList, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data?.error ?? false))
            {
                throw new Exception(api_Data.errormessage);
            }
            return api_Data.data;
        }
    }
}