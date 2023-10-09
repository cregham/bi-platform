using CsvHelper.Configuration;

namespace BI_Platform.Models.CallRecord
{
    public sealed class CallRecordClassMap : ClassMap<CallRecord>
    {
        public CallRecordClassMap()
        {
            Map(m => m.CallerId).Name("caller_id");
            Map(m => m.Recipient).Name("recipient");
            Map(m => m.CallDate).Name("call_date").TypeConverterOption.Format("dd/MM/yyyy");
            Map(m => m.EndTime).Name("end_time");
            Map(m => m.Duration).Name("duration");
            Map(m => m.Cost).Name("cost");
            Map(m => m.Reference).Name("reference");
            Map(m => m.Currency).Name("currency");
        }
    }
}
