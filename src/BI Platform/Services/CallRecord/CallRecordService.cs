using BI_Platform.Common.Storage;
using BI_Platform.Models.CallRecord;
namespace BI_Platform.Services.CallRecordService
{
    public class CallRecordService : ICallRecordService
    {
        private List<CallRecord> _callRecordContext;

        public CallRecordService()
        {
            //In liu of live storage, use a singleton cache
            _callRecordContext = CallRecordContext.Instance;
        }

        public List<CallRecord> GetAllRecords()
        {
            return _callRecordContext;
        }
    }
}
