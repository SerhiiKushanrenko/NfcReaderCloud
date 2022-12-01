using BLL.DTOs;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NfcReaderCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly ICheckDataService _checkDataService;
        public UserInfoController(ICheckDataService checkDataService)
        {
            _checkDataService = checkDataService;
        }

        [HttpPost]
        public IActionResult CheckUser(UserAuthDTO user)
        {
            _checkDataService.Check(user);
            return Ok();
        }

    }
}
