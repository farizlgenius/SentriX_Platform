

using Identity.Contract.DTOs;

namespace Identity.Contract.Interfaces;

public interface IJwtService
{
  Task<TokenDto> GenerateTokenAsync(UserInTokenDto user);
  Task<TokenDto> RefreshTokenAsync(UserInTokenDto refreshToken);
  Task<bool> RevokeTokenAsync(string refreshToken);
  Task<RefreshTokenDto> GetRefreshTokenAsync(string hashed);
}
