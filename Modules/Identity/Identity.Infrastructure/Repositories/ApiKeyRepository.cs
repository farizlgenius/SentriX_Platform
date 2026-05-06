using System;
using Identity.Contract.DTOs;
using Identity.Domain.Entities;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Identity.Application.Interfaces;

namespace Identity.Infrastructure.Repositories;

public sealed class ApiKeyRepository(AppDbContext context) : IApiKeyRepository
{
  public async Task<ApiKeyDto> ValidateApiKeyAsync(string apiKey)
  {
    return await context.ApiKeys
      .AsNoTracking()
      .OrderBy(x => x.created_at)
      .Where(x => x.key.Equals(apiKey))
      .Select(x => new ApiKeyDto(x.key, x.owner, x.is_active, x.ExpireAt))
      .FirstOrDefaultAsync() ?? new ApiKeyDto(string.Empty, string.Empty, false, DateTime.MinValue);
  }
}
