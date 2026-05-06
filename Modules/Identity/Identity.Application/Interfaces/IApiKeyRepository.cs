using System;
using Identity.Contract.DTOs;


namespace Identity.Application.Interfaces;

public interface IApiKeyRepository
{
  Task<ApiKeyDto> ValidateApiKeyAsync(string apiKey);
}
