using System;
using Core.Application.DTOs;

namespace Core.Application.Interfaces;

public interface IBaseRepository<X, Y>
{
  Task<PaginationDto<X>> GetPaginationByLocationIdAsync(int location, int Page, int PageSize);
  Task<X> CreateAsync(Y domain);
  Task<X> UpdateAsync(Y domain);
  Task<X> DeleteByIdAsync(int id);
  Task<bool> IsAnyNameExceptIdAsync(string Name, int Id);
  Task<bool> IsAnyIdAsync(int Id);
  Task<bool> IsAnyNameExceptLocationIdAsync(string Name, int LocationId);
}
