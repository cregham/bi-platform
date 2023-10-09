using BI_Platform.Models.CallRecord;

namespace BI_Platform.Services.CallRecordService
{
    public interface ICallRecordService
    {
        //General
        List<CallRecord> GetAllRecords();
    }
}