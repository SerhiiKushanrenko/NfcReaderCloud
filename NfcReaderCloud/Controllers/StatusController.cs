using Microsoft.AspNetCore.Mvc;

namespace NfcReaderCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStatus()
        {
            return Ok();
        }
    }
}
