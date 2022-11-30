using BLL.DTOs;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NfcReaderCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfo : ControllerBase
    {
        private readonly ICheckService _checkService;
        public UserInfo(ICheckService checkService)
        {
            _checkService = checkService;
        }

        [HttpPost]
        public IActionResult CheckUser(UserDTO user)
        {
            _checkService.Check(user);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
