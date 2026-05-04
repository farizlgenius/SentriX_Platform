using Core.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocketController(ISockerService service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> TestSockerAsync([FromBody] string Message )
        {
            var res = await service.TestSocketAsync(Message);
            return Ok(res);
        }
    }
}
