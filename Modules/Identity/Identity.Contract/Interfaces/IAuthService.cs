


using Identity.Contract.DTOs;

namespace Identity.Contract.Interfaces;

public interface IAuthService
{
  Task<TokenDto> LoginAsync(LoginDto loginDto);
  Task<TokenDto> RefreshTokenAsync(string refreshToken);
  Task<BaseDto> LogoutAsync(string refreshToken);
  Task<MeDto> GetMeByUsernameAndRoleIdAsync(string username, int roleId);

}
