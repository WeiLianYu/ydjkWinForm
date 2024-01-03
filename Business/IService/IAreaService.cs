using System.Collections.Generic;
using System.Threading.Tasks;
using 移动家客WinApp.Model.Output.System;

namespace 移动家客WinApp.Business.IService
{
    public interface IAreaService
    {
        /// <summary>
        /// 获取地市
        /// </summary>
        /// <returns></returns>
        Task<List<AreaDto>> GetList(string parentId = "420000");
    }
}