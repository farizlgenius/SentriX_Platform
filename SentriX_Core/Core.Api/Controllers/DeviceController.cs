using Core.Application.DTOs;
using Core.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController(IDeviceService service) : ControllerBase
    {
        [HttpGet("/api/{location}/[controller]/pagination")]
        public async Task<IActionResult> GetPaginationByLocationIdAsync(int location, [FromQuery] int Page, [FromQuery] int PageSize)
        {
            var res = await service.GetPaginationByLocationIdAsync(location, Page, PageSize);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateDeviceDto dto)
        {
            var res = await service.CreateAsync(dto);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateDeviceDto dto)
        {
            var res = await service.UpdateAsync(dto);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var res = await service.DeleteByIdAsync(id);
            return Ok(res);
        }
    }
}
