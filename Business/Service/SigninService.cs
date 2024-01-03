using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using 移动家客WinApp.Business.IService;
using 移动家客WinApp.Comm;
using 移动家客WinApp.Model.Output.Signin;

namespace 移动家客WinApp.Business.Service
{
    internal class SigninService : BaseService, ISigninService
    {
        //验证码
        private static readonly string api_Base_ImageCaptcha = GetApiUrl("Admin/User/ImageCaptcha");

        //登录
        private static readonly string api_Base_LoginAsync = GetApiUrl("Admin/User/LoginAsync");

        public SigninService()
        {
        }

        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetImageCaptcha()
        {
            var api_Data_ImageCaptcha = await HttpWebRequestHelper.HttpApi<ImageCaptchaDto>(api_Base_ImageCaptcha, null, "Get", null);
            if ((api_Data_ImageCaptcha?.error ?? false))
            {
                throw new Exception(api_Data_ImageCaptcha.errormessage);
            }
            var ImageCaptcha = api_Data_ImageCaptcha?.data?.code;
            return ImageCaptcha;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="imageCaptcha"></param>
        /// <returns></returns>
        public async Task<UserAndTokenDto> Signin(string username, string password, string imageCaptcha)
        {
            var json_data = new
            {
                username = username,
                password = password,
                code = imageCaptcha,
                isapp = false
            };
            var api_Data_Token = await HttpWebRequestHelper.HttpApi<UserAndTokenDto>(api_Base_LoginAsync, JsonConvert.SerializeObject(json_data), "Post", null);
            if ((api_Data_Token?.error ?? false))
            {
                throw new Exception(api_Data_Token.errormessage);
            }
            token = api_Data_Token?.data?.token?.access_token;
            UserId = api_Data_Token?.data?.data?.id;
            return api_Data_Token?.data;
        }
    }
}