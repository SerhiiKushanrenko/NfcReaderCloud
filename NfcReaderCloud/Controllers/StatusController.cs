using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NfcReaderCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {

        private readonly IAppStatusService _appStatusService;

        public StatusController(IAppStatusService appStatusService)
        {
            _appStatusService = appStatusService;
        }


        [HttpGet]
        public IActionResult GetStatus()
        {
            return Ok(_appStatusService.GetAppStatus());
        }
    }
}
