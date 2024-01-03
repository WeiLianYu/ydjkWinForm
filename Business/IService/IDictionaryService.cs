using System.Threading.Tasks;
using 移动家客WinApp.Model.Output.System;

namespace 移动家客WinApp.Business.IService
{
    public interface IDictionaryService
    {
        /// <summary>
        /// 获取终端型号
        /// </summary>
        /// <returns></returns>
        Task<DictionaryDto> GetList(string type);
    }
}