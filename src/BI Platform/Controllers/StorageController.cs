using BI_Platform.Common;
using BI_Platform.Common.Storage;
using Microsoft.AspNetCore.Mvc;

namespace BI_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        [HttpPost("csv")]
        public IActionResult UploadCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            if (Path.GetExtension(file.FileName) != ".csv")
            {
                return BadRequest("File is not a CSV.");
            }

            var csvDeserializer = new CsvDeserializer();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var callRecords = csvDeserializer.Deserialize(reader);
                CallRecordContext.Instance.AddRange(callRecords);
            }

            return Ok("File processed");
        }
    }
}
