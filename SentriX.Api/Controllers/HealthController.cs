using System.Net;
using Identity.Contract.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace SentriX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                new HealthDto(HttpStatusCode.OK, "Service is healthy", DateTime.UtcNow)
            );

        }
    }
}
