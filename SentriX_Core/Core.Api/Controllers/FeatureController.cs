using Core.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController(IFeatureService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var features = await service.GetAsync();
            return Ok(features);
        }

        [HttpGet("ids")]
        public async Task<IActionResult> GetIdsAsync()
        {
            var features = await service.GetIdsAsync();
            return Ok(features);
        }
    }
}
