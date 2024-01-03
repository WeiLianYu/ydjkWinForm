using System.Threading.Tasks;
using 移动家客WinApp.Model.Input.ScrapRecord;
using 移动家客WinApp.Model.Output.ScrapRecord;

namespace 移动家客WinApp.Business.IService
{
    public interface IFxScrapRecordService
    {
        Task<FxScrapRecordListDto> GetList(GetScrapRecordListInput model);

        Task<FxScrapRecordDto> GetInfo(string Id);

        Task Add(AddScrapRecordInput model);

        Task Edit(EditScrapRecordInput model);

        Task Del(string Id);
    }
}