using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using 移动家客WinApp.Business.IService;
using 移动家客WinApp.Comm;
using 移动家客WinApp.Model.Input.QR;
using 移动家客WinApp.Model.Output.QR;

namespace 移动家客WinApp.Business.Service
{
    internal class FxQRTemplateService : BaseService, IFxQRTemplateService
    {
        //获取终端型号列表
        private static readonly string api_GetFxBoxList = GetApiUrl("TerminalModel/TerminalModel/GetQRTemplateList");

        private static readonly string api_GetContrastInfo = GetApiUrl("Bussiness/Fx/GetContrastInfo");

        public FxQRTemplateService()
        {
        }

        public async Task<ContrastInfo> GetContrastInfo(GetContrastInfoDto model)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }

            var api_Data = await HttpWebRequestHelper.HttpApi<ContrastInfo>(api_GetContrastInfo, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data?.error ?? false))
            {
                throw new Exception(api_Data.errormessage);
            }
            return api_Data?.data;
        }

        public async Task<QRTemplateDto> GetQRInfo(GetInfo_QRDto model)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("token is null");
            }

            var api_Data = await HttpWebRequestHelper.HttpApi<QRTemplateDto>(api_GetFxBoxList, JsonConvert.SerializeObject(model), "Post", token);
            if ((api_Data?.error ?? false))
            {
                throw new Exception(api_Data.errormessage);
            }
            return api_Data?.data;
        }
    }
}