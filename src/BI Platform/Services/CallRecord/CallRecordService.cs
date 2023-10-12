using BI_Platform.Common.Storage;
using BI_Platform.Models.CallRecord;
using System.Globalization;

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

        public IGrouping<DayOfWeek, CallRecord>[] GetPeakUsage()
        {
            return _callRecordContext
             .GroupBy(cr => cr.CallDate.DayOfWeek)
             .OrderByDescending(g => g.Count())
             .ToArray();
        }

        public List<CallerLongestStreak> LongestDailyCallStreakPerCaller()
        {
            var callers = _callRecordContext
                .GroupBy(cr => cr.CallerId);

            var results = new List<CallerLongestStreak>();

            foreach (var caller in callers)
            {
                var dates = caller.Select(c => c.CallDate.Date).Distinct().OrderBy(d=>d).ToList();

                List<DateTime> currentStreakDates = new List<DateTime>() { dates[0] };
                List<DateTime> longestStreakDates = new List<DateTime>() { dates[0] };

                for (int i = 1; i < dates.Count; i++)
                {
                    if ((dates[i] - dates[i - 1]).TotalDays == 1)
                    {
                        currentStreakDates.Add(dates[i]);

                        if (currentStreakDates.Count > longestStreakDates.Count)
                        {
                            longestStreakDates = new List<DateTime>(currentStreakDates);
                        }
                    }
                    else
                    {
                        currentStreakDates.Clear();
                        currentStreakDates.Add(dates[i]);
                    }
                }

                if(longestStreakDates.Count > 1)
                {
                    results.Add(new CallerLongestStreak(caller.Key, longestStreakDates));
                }
            }
            return results.OrderByDescending(r => r.Streak).ToList();
        }
    }
}
