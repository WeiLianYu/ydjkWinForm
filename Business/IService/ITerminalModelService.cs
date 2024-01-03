using System.Threading.Tasks;
using 移动家客WinApp.Model.Input.Terminal;
using 移动家客WinApp.Model.Output.Terminal;

namespace 移动家客WinApp.Business.IService
{
    public interface ITerminalModelService
    {
        /// <summary>
        /// 获取终端型号列表
        /// </summary>
        Task<TerminalModelDto> GetList(GetList_TerminalModelDto model);

        Task<TerminalModelInfo> GetInfo(int Id);
    }
}