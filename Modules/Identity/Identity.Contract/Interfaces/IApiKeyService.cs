using Identity.Contract.DTOs;

namespace Identity.Contract.Interfaces;

public interface IApiKeyService
{
  Task<ApiKeyDto> ValidateApiKeyAsync(string apiKey);
}
