using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using 移动家客WinApp.Business.IService;
using 移动家客WinApp.Comm;
using 移动家客WinApp.Model.Input.Fx;
using 移动家客WinApp.Model.Output.Fx;
using System.Linq;
using 移动家客WinApp.Model.Output;

namespace 移动家客WinApp.Business.Service
{
    internal class FxTerminalAccountService : BaseService, IFxTerminalAccountService
    {
        //获取终端列表
        private static readonly string api_GetFxTerminalAccountList = GetApiUrl("Bussiness/Fx/GetFxTerminalAccountList");

        private static readonly string api_GetFxTerminalAccount = GetApiUrl("Bussiness/Fx/SortingList");

        //获取终端信息
        private static readonly string api_GetFxBoxInfo = GetApiUrl("Bussiness/Fx/GetFxTerminalAccountInfo");

        //添加终端
        private static readonly string api_SealingBoxDto = GetApiUrl("Bussiness/Fx/SealingBox");

        //装箱移除终端
        private static readonly string api_DelFxTerminalAccount = GetApiUrl("Bussiness/Fx/BoxDelet");

        public FxTerminalAccountService()
        {
        }

        public void Add(Add_FxTerminalAccountDto model)
        {
            throw new NotImplementedException();
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
            var api_Data = await HttpWebRequestHelper.HttpApi<string>(api_DelFxTerminalAccount, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data?.error ?? false))
            {
                throw new Exception(api_Data.errormessage);
            }
            return;
        }

        public async Task<FxTerminalAccountListDto> GetList(GetList_FxTerminalAccountDto model)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }

            var api_Data = await HttpWebRequestHelper.HttpApi<FxTerminalAccountListDto>(api_GetFxTerminalAccountList, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data?.error ?? false))
            {
                throw new Exception(api_Data.errormessage);
            }
            return api_Data.data;
        }

        public async Task<int> SealingBox(SealingBoxDto model)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }

            var api_Data = await HttpWebRequestHelper.HttpApi<int?>(api_SealingBoxDto, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data?.error ?? false))
            {
                throw new Exception(api_Data.errormessage);
            }
            return api_Data.data.Value;
        }

        public async Task<FxTerminalAccountDto> Get(Get_FxTerminalAccountDto model)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }

            var api_Data = await HttpWebRequestHelper.HttpApi<FxTerminalAccountListDto>(api_GetFxTerminalAccount, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data?.error ?? false))
            {
                throw new Exception(api_Data.errormessage);
            }
            return api_Data.data?.list?.FirstOrDefault();
        }

        public FxTerminalAccountDto Info(string Id)
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
        }

        public void SealingBox()
        {
            throw new NotImplementedException();
        }
    }
}