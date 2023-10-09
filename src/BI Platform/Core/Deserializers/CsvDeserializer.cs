using System.Formats.Asn1;
using System.Globalization;
using System;
using CsvHelper;
using CsvHelper.Configuration;
using BI_Platform.Models.CallRecord;

namespace BI_Platform.Core.Deserializers
{
    public class CsvDeserializer
    {
        public IEnumerable<CallRecord> Deserialize(StreamReader stream)
        {
            using (var csvReader = new CsvReader(stream, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csvReader.Context.RegisterClassMap<CallRecordClassMap>();
                return csvReader.GetRecords<CallRecord>().ToList();
            }
        }
    }
}
