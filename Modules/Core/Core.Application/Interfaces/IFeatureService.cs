using System;
using Core.Application.DTOs;

namespace Core.Application.Interfaces;

public interface IFeatureService
{
      Task<List<FeatureDto>> GetAsync();
      Task<List<int>> GetIdsAsync();
}
