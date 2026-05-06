using System;
using Core.Application.Interfaces;
using Core.Contract.DTOs;
using Core.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Repositories;

public sealed class FeatureRepository(AppDbContext context) : IFeatureRepository
{
      public async Task<List<FeatureDto>> GetAsync()
      {
            return await context.Features.AsNoTracking().OrderByDescending(x => x.id).Select(f => new FeatureDto(f.id, f.name)).ToListAsync();
      }

      public async Task<List<int>> GetIdsAsync()
      {
            var featureIds = await context.Features.AsNoTracking().Select(f => f.id).ToListAsync();
            return featureIds;
      }
}
