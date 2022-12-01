using BLL.DTOs;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NfcReaderCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly ICheckDataService _checkService;
        public UserInfoController(ICheckDataService checkService)
        {
            _checkService = checkService;
        }

        [HttpPost]
        public IActionResult CheckUser(UserDTO user)
        {
            _checkService.Check(user);
            return Ok();
        }

    }
}
