using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using 移动家客WinApp.Business.IService;
using 移动家客WinApp.Comm;
using 移动家客WinApp.Model.Input.Fx;
using 移动家客WinApp.Model.Output.Fx;

namespace 移动家客WinApp.Business.Service
{
    internal class FxBoxService : BaseService, IFxBoxService
    {
        //获取封装箱列表
        private static readonly string api_GetFxBoxList = GetApiUrl("Bussiness/Fx/GetFxBoxList");

        //获取封装箱
        private static readonly string api_GetFxBoxInfo = GetApiUrl("Bussiness/Fx/GetFxBoxInfo");

        //添加封装箱
        private static readonly string api_AddFxBox = GetApiUrl("Bussiness/Fx/AddFxBox");

        //删除封装箱
        private static readonly string api_DelFxBox = GetApiUrl("Bussiness/Fx/DelFxBox");

        //删除封箱
        private static readonly string api_ColseBox = GetApiUrl("Bussiness/Fx/ColseBox");

        //修改包装箱状态
        private static readonly string api_EidtBoxState = GetApiUrl("Bussiness/Fx/EidtBoxState");

        public FxBoxService()
        {
        }

        public async Task<FxBoxDto> Add(Add_FxBoxDto model)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }

            var api_Data_Token = await HttpWebRequestHelper.HttpApi<FxBoxDto>(api_AddFxBox, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data_Token?.error ?? false))
            {
                throw new Exception(api_Data_Token.errormessage);
            }
            return api_Data_Token.data;
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
            var api_Data = await HttpWebRequestHelper.HttpApi<FxBoxDto>(api_DelFxBox, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data?.error ?? false))
            {
                throw new Exception(api_Data.errormessage);
            }
            return;
        }

        public async Task<FxBoxDto> Info(string Id)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }

            var model = new
            {
                Id = Id
            };
            var api_Data = await HttpWebRequestHelper.HttpApi<FxBoxDto>(api_GetFxBoxInfo, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data?.error ?? false))
            {
                throw new Exception(api_Data.errormessage);
            }
            return api_Data.data;
        }

        public string GenerateBatchNum()
        {
            var area1 = "武汉市";
            var area2 = "江岸区";
            var tiem = "20220420";
            var mum = "001";
            return $"{area1}{area2}{tiem}{mum}";
        }

        public async Task<FxBoxListDto> GetList(GetList_FxBoxDto model)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }

            var api_Data = await HttpWebRequestHelper.HttpApi<FxBoxListDto>(api_GetFxBoxList, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data?.error ?? false))
            {
                throw new Exception(api_Data.errormessage);
            }
            return api_Data.data;
        }

        public async Task ColseBox(string Id)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }

            var model = new
            {
                Id = Id
            };
            var api_Data = await HttpWebRequestHelper.HttpApi<string>(api_ColseBox, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data?.error ?? false))
            {
                throw new Exception(api_Data.errormessage);
            }
        }

        public async Task EidtBoxState(EidtBoxStateDto model)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }
            var api_Data = await HttpWebRequestHelper.HttpApi<string>(api_EidtBoxState, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data?.error ?? false))
            {
                throw new Exception(api_Data.errormessage);
            }
            return;
        }
    }
}