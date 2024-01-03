using System.Threading.Tasks;
using 移动家客WinApp.Model.Input.Fx;
using 移动家客WinApp.Model.Output.Fx;

namespace 移动家客WinApp.Business.IService
{
    public interface IFxLogisticsService
    {
        /// <summary>
        /// 获取物流单
        /// </summary>
        Task<FxLogisticsListDto> GetList(GetList_LogisticsDto model);

        Task<FxLogisticsDto> GetInfo(string Id);

        Task<FxLogisticsDto> Add(Add_FxLogisticsDto model);
    }
}