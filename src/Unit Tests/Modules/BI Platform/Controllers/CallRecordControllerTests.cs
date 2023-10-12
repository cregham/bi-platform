using BI_Platform.Controllers;
using BI_Platform.Models.CallRecord;
using BI_Platform.Services.CallRecordService;
using Unit_Tests.Utilities;

namespace Unit_Tests.Modules.BI_Platform.Controllers
{
    [TestClass]
    public class CallRecordControllerTests
    {
        private CallRecordService _service;
        private CallRecordController _controller;

        public CallRecordControllerTests()
        {
            _service = new CallRecordService();
            _controller = new CallRecordController(_service);
        }

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            CallRecordContextTestHelper.Populate();
        }

        [TestMethod]
        public void controller_Get_ReturnsNotNull()
        {
            var result = _controller.Get();
            var callRecords = result.Value;
            
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(callRecords, typeof(List<CallRecord>));
            Assert.AreEqual(callRecords.Count, 40);
        }

        [TestMethod]
        public void controller_GetPeakUsage_ReturnsHourly()
        {
            var result = _controller.GetPeakUsageTimes();
            var peakTimeGroups = result.Value;

            Assert.IsNotNull(peakTimeGroups);
            Assert.IsInstanceOfType(peakTimeGroups, typeof(List<CallsByHour>));
            Assert.AreEqual(peakTimeGroups.Count, 7);

            var orderedTestList = peakTimeGroups.OrderByDescending(p => p.CallCount);
            Assert.IsTrue(orderedTestList.SequenceEqual(peakTimeGroups));
        }

        [TestMethod]
        public void controller_GetLongestDailyCallStreak()
        {
            var result = _controller.GetLongestDailyCallStreak();
            var longestStreaks = result.Value;

            Assert.IsNotNull(longestStreaks);
            Assert.IsInstanceOfType(longestStreaks, typeof(List<CallerLongestStreak>));
            foreach (var longestStreak in longestStreaks)
            {
                for (int i = 1; i < longestStreak.Dates.Count; i++) {
                    Assert.IsTrue((longestStreak.Dates[i] - longestStreak.Dates[i - 1]).TotalDays == 1);
                }
            }

            var orderedTestList = longestStreaks.OrderByDescending(p => p.Streak);
            Assert.IsTrue(orderedTestList.SequenceEqual(longestStreaks));
        }
    }
}
