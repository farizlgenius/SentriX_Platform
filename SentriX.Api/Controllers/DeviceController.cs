using AeroAdapter.Application.DTOs;
using AeroAdapter.Application.Memories;
using Core.Application.Interfaces;
using Core.Contract.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace SentriX.Api.Controllers
{
    [Route("api/core/[controller]")]
    [ApiController]
    public class DeviceController(IdReports reports,IDeviceService service) : ControllerBase
    {
        [HttpGet("report")]
        public async Task<IActionResult> GetIdReportsAsync()
        {
            return Ok(reports.IdReportInMemory);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateDeviceDto dto )
        {
            var res = await service.CreateAsync(dto);
            return Ok();
        }
    }
}
