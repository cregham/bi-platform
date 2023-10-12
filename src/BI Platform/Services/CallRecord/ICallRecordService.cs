using BI_Platform.Models.CallRecord;

namespace BI_Platform.Services.CallRecordService
{
    public interface ICallRecordService
    {
        List<CallRecord> GetAllRecords();

        IGrouping<DayOfWeek, CallRecord>[] GetPeakUsage();

        List<CallerLongestStreak> LongestDailyCallStreakPerCaller();
    }
}