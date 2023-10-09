using BI_Platform.Common.Storage;
using BI_Platform.Models.CallRecord;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BI_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallRecordController : ControllerBase
    {
        public List<CallRecord> _callRecordService;
        public CallRecordController()
        {
            //In liu of live storage, use a singleton. Scope is application runtime
            _callRecordService = CallRecordContext.Instance;
        }

        [HttpGet]
        public ActionResult<List<CallRecord>> Get()
        {
            if (_callRecordService == null || _callRecordService.Count == 0)
            {
                return NotFound("No records found.");
            }

            return Ok(_callRecordService);
        }
    }
}
