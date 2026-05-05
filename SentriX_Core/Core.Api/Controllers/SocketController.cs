using Core.Application.DTOs;
using Core.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocketController(IBrokerService service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> TestSocketAsync([FromBody] MessageBrokerDto Message )
        {
            var res = await service.TestBrokerService(Message);
            return Ok(res);
        }
    }
}
