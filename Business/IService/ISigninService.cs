using System.Threading.Tasks;
using 移动家客WinApp.Model.Output.Signin;

namespace 移动家客WinApp.Business.IService
{
    public interface ISigninService
    {
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        Task<string> GetImageCaptcha();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="imageCaptcha">验证码</param>
        /// <returns>Token和用户信息</returns>
        Task<UserAndTokenDto> Signin(string username, string password, string imageCaptcha);
    }
}