using System;
using Core.Application.DTOs;
using Core.Application.Interfaces;

namespace Core.Application.Services;

public sealed class FeatureService(IFeatureRepository repo) : IFeatureService
{
      public async Task<List<FeatureDto>> GetAsync()
      {
            return await repo.GetAsync();
      }

      public async Task<List<int>> GetIdsAsync()
      {
            return await repo.GetIdsAsync();
      }
}
