using BI_Platform.Common.Storage;
using BI_Platform.Models.CallRecord;
using BI_Platform.Services.CallRecordService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BI_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallRecordController : ControllerBase
    {
        private ICallRecordService _callRecordService;

        public CallRecordController(ICallRecordService callRecordService)
        {
            _callRecordService = callRecordService;
        }

        [HttpGet]
        public ActionResult<List<CallRecord>> Get()
        {
            return _callRecordService.GetAllRecords();
        }

        [HttpGet("peakUsageTimes")]
        public ActionResult<List<CallsByHour>> GetPeakUsageTimes()
        {
            try
            {
                var peakTimesGroups = _callRecordService.GetPeakUsage();
                return peakTimesGroups.Select(g => new CallsByHour() { Day = g.Key.ToString(), CallCount = g.Count() }).ToList();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpGet("dailyCallStreakPerCaller")]
        public ActionResult<List<CallerLongestStreak>> GetLongestDailyCallStreak()
        {
            try
            {
                return _callRecordService.LongestDailyCallStreakPerCaller();   
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
