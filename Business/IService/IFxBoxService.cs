using System.Threading.Tasks;
using 移动家客WinApp.Model.Input.Fx;
using 移动家客WinApp.Model.Output.Fx;

namespace 移动家客WinApp.Business.IService
{
    public interface IFxBoxService
    {
        /// <summary>
        /// 生成批次号
        /// </summary>
        /// <returns></returns>
        string GenerateBatchNum();

        /// <summary>
        /// 添加封装箱
        /// </summary>
        Task<FxBoxDto> Add(Add_FxBoxDto model);

        /// <summary>
        /// 删除封装箱
        /// </summary>
        /// <param name="Id"></param>
        Task Del(string Id);

        /// <summary>
        /// 获取封装箱信息
        /// </summary>
        Task<FxBoxDto> Info(string Id);

        /// <summary>
        /// 获取包装箱列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        Task<FxBoxListDto> GetList(GetList_FxBoxDto model);

        /// <summary>
        /// 封箱
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task ColseBox(string Id);

        Task EidtBoxState(EidtBoxStateDto model);
    }
}