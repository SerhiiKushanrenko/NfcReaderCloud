using BLL.DTOs;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NfcReaderCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddGuidController : ControllerBase
    {
        private readonly IAddGuidService _addGuidService;
        public AddGuidController(IAddGuidService addGuidService)
        {
            _addGuidService = addGuidService;
        }

        [HttpPost]
        public async Task<IActionResult> AddGuid([FromBody] WebDataDTO pageDto)
        {
            await _addGuidService.AddGuidToList(pageDto);
            return Ok();
        }

    }
}
