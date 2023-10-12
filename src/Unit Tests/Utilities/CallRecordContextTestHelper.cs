using BI_Platform.Common.Storage;
using BI_Platform.Core.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests.Utilities
{
    internal static class CallRecordContextTestHelper
    {
        public static void Populate()
        {
            string filePath = @".\Data\techtest_cdr.csv";

            var csvDeserializer = new CsvDeserializer();
            using (var reader = new StreamReader(filePath))
            {
                var callRecords = csvDeserializer.Deserialize(reader);
                CallRecordContext.Instance.AddRange(callRecords);
            }
        }
    }
}
