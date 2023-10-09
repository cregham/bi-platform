namespace BI_Platform.Models.CallRecord
{
    public class CallRecord
    {
        public string CallerId { get; set; } = string.Empty;        // Phone number of the caller
        public string Recipient { get; set; } = string.Empty;       // Phone number of the number dialed
        public DateTime CallDate { get; set; } = DateTime.MinValue; // Date on which the call was made
        public TimeSpan EndTime { get; set; } = TimeSpan.Zero;      // Time when the call ended
        public int Duration { get; set; } = 0;                      // Duration of the call in seconds
        public decimal Cost { get; set; } = new decimal();          // The billable cost of the call to 3 decimal places
        public string Reference { get; set; } = string.Empty;       // Unique reference for the call
        public string Currency { get; set; } = string.Empty;        // Currency for the cost in ISO alpha-3 format 
    }
}
