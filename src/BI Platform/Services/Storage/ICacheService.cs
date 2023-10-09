using BI_Platform.Models.CallRecord;

namespace BI_Platform.Services.Storage
{
    public interface ICacheService
    {
        public void Add(CallRecord callRecord);
        public void Add(IEnumerable<CallRecord> callRecords);
    }
}
