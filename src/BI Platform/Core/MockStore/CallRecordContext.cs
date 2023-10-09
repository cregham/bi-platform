using BI_Platform.Models.CallRecord;

namespace BI_Platform.Common.Storage
{
    //Fake storage
    public sealed class CallRecordContext
    {
        private static List<CallRecord>? instance = null;
        private CallRecordContext()
        { }

        public static List<CallRecord> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new List<CallRecord>();
                }
                return instance;
            }
        }
    }
}
