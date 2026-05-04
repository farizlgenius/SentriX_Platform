using System;
using Core.Application.DTOs;

namespace Core.Application.Interfaces;

public interface IBaseService<X, Y, Z>
{
  Task<PaginationDto<X>> GetPaginationByLocationIdAsync(int location, int Page, int PageSize);
  Task<X> CreateAsync(Y dto);
  Task<X> UpdateAsync(Z dto);
  Task<X> DeleteByIdAsync(int id);
}
