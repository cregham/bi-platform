using BI_Platform.Common.Storage;
using BI_Platform.Models.CallRecord;

namespace BI_Platform.Services.Storage
{
    public class CacheService : ICacheService
    {
        public List<CallRecord> _cache;

        public CacheService()
        {
            _cache = CallRecordContext.Instance;
        }

        public void Add(CallRecord callRecord)
        {
            _cache.Add(callRecord);
        }

        public void Add(IEnumerable<CallRecord> callRecords)
        {
            foreach (var callRecord in callRecords)
            {
                Add(callRecord);
            }
        }
    }
}
