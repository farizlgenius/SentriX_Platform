using System.Security.Claims;
using Identity.Application.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Identity.Contract.Interfaces;
using Identity.Contract.DTOs;

namespace SentriX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService service) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginDto dto)
        {
            var token = await service.LoginAsync(dto);

            Response.Cookies.Append("refresh_token", token.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                // Path = "/api/Auth",
                Expires = new DateTimeOffset(token.RefreshExpiredAt, TimeSpan.Zero)
            });

            return Ok(token);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshAsync([FromBody] RefreshDto dto)
        {

            if (string.IsNullOrWhiteSpace(dto.Refresh))
            {
                string? refreshToken;
                Request.Cookies.TryGetValue("refresh_token", out refreshToken);
                var result = await service.RefreshTokenAsync(refreshToken ?? "");
                 Response.Cookies.Append("refresh_token", result.RefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    // Path = "/api/Auth",
                    Expires = new DateTimeOffset(result.RefreshExpiredAt, TimeSpan.Zero)
                });
                return Ok(result);
            }
            else
            {
                var result = await service.RefreshTokenAsync(dto.Refresh);
                Response.Cookies.Append("refresh_token", result.RefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    // Path = "/api/Auth",
                    Expires = new DateTimeOffset(result.RefreshExpiredAt, TimeSpan.Zero)
                });
                return Ok(result);
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] RefreshDto dto)
        {

            if (string.IsNullOrWhiteSpace(dto.Refresh))
            {
                string? refreshToken;
                Request.Cookies.TryGetValue("refresh_token", out refreshToken);
                var result = await service.LogoutAsync(refreshToken ?? "");
                Response.Cookies.Delete("refresh_token", new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    // Path = "/api/Auth"
                });
                return Ok(result);
            }
            else
            {
                var result = await service.LogoutAsync(dto.Refresh);
                Response.Cookies.Delete("refresh_token", new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    // Path = "/api/Auth"
                });
                return Ok(result);
            }
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetMe()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
            var role_id = User.FindFirst("role_id")?.Value ?? "";

            var result = await service.GetMeByUsernameAndRoleIdAsync(username, int.Parse(role_id));
            return Ok(result);

        }


        [HttpPost("hash")]
        public async Task<IActionResult> GetHash([FromBody] string password)
        {
            var res = PasswordHasher.HashPassword(password);
            return Ok(res);
        }
    }
}
