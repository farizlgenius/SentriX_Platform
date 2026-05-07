using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UINotifier.Contract.DTOs;
using UINotifier.Contract.Interfaces;

namespace SentriX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyController(INotifier notifier) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> NotifyAsync([FromBody]NotifierDto dto)
        {
            await notifier.SendToTopic(dto.Key,dto.Data);
            return Ok();
        }
    }
}
