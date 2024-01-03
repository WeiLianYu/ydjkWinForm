using System.Threading.Tasks;
using 移动家客WinApp.Model.Input.Fx;
using 移动家客WinApp.Model.Output.Fx;

namespace 移动家客WinApp.Business.IService
{
    public interface IFxTerminalAccountService
    {
        /// <summary>
        /// 添加封装箱
        /// </summary>
        void Add(Add_FxTerminalAccountDto model);

        /// <summary>
        /// 删除封装箱
        /// </summary>
        /// <param name="Id"></param>
        Task Del(string Id);

        /// <summary>
        /// 获取封装箱信息
        /// </summary>
        FxTerminalAccountDto Info(string Id);

        /// <summary>
        /// 封箱
        /// </summary>
        void SealingBox();

        /// <summary>
        /// 打印
        /// </summary>
        void Print();

        /// <summary>
        /// 获取包装箱列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        Task<FxTerminalAccountListDto> GetList(GetList_FxTerminalAccountDto model);

        Task<FxTerminalAccountDto> Get(Get_FxTerminalAccountDto model);

        /// <summary>
        /// 装箱
        /// </summary>
        /// <param name="model"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        Task<int> SealingBox(SealingBoxDto model);
    }
}