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
        private readonly ICheckDataService _checkDataService;
        private readonly IUserService _userService;
        public UserInfoController(ICheckDataService checkDataService, IUserService userService)
        {
            _checkDataService = checkDataService;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CheckUser(UserAuthDTO user)
        {
            _checkDataService.Check(user);
            return Ok();
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User user)
        {
            var result = _userService.CreateUser(user);
            return Ok(result);
        }

    }
}
