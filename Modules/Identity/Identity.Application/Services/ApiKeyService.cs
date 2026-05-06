


using Identity.Application.Interfaces;
using Identity.Contract.DTOs;
using Identity.Contract.Interfaces;

namespace Identity.Application.Services;

public sealed class ApiKeyService(IApiKeyRepository repo) : IApiKeyService
{
  public async Task<ApiKeyDto> ValidateApiKeyAsync(string apiKey)
  {
    return await repo.ValidateApiKeyAsync(apiKey);
  }
}
