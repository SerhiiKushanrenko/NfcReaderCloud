using BLL.DTOs;
using BLL.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace NfcReaderCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public UserInfoController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CheckUser(UserAuthDTO user)
        {
            _authService.Check(user);
            return Ok();
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User user)
        {
            _userService.CreateUser(user);
            return Ok();
        }

    }
}
