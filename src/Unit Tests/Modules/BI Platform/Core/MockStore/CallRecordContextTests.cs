using BI_Platform.Common.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests.Modules.BI_Platform.Core.MockStore
{
    [TestClass]
    public class CallRecordContextTests
    {
        [TestMethod]
        public void CallRecordContext_IsNever_Null()
        {
            Assert.IsNotNull(CallRecordContext.Instance);
        }
    }
}
