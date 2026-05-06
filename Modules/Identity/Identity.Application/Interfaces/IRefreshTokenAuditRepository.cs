

using Identity.Contract.DTOs;
using Identity.Domain.Entities;


namespace Identity.Application.Interfaces;

public interface IRefreshTokenAuditRepository
{
  Task AddAsync(string username, string hashedRefreshToken, string action, DateTime expiredAt);
  Task<RefreshToken> GetRefreshTokenAsync(string hash);
}
