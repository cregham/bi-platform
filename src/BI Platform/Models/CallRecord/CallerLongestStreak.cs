namespace BI_Platform.Models.CallRecord
{
    public class CallerLongestStreak
    {
        public CallerLongestStreak(string callerID, List<DateTime> dates)
        {
            CallerID = callerID;
            Dates = dates;
        }

        public string CallerID { get; private set; } = string.Empty;
        public List<DateTime> Dates { get; private set; } = new List<DateTime>();
        public int Streak => Dates.Count();

    }
}
