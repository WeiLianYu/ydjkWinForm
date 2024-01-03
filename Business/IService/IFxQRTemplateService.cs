using System.Threading.Tasks;
using 移动家客WinApp.Model.Input.QR;
using 移动家客WinApp.Model.Output.QR;

namespace 移动家客WinApp.Business.IService
{
    public interface IFxQRTemplateService
    {
        /// <summary>
        /// 获取扫码设置信心
        /// </summary>
        Task<QRTemplateDto> GetQRInfo(GetInfo_QRDto model);

        /// <summary>
        /// 获取大数据SN型号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        Task<ContrastInfo> GetContrastInfo(GetContrastInfoDto model);
    }
}