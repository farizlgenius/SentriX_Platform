using System;
using Core.Application.DTOs;

namespace Core.Application.Interfaces;

public interface IFeatureRepository
{
      Task<List<FeatureDto>> GetAsync();
      Task<List<int>> GetIdsAsync();
}
