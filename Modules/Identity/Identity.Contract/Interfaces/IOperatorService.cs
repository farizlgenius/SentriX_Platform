



using Identity.Contract.DTOs;

namespace Identity.Contract.Interfaces;

public interface IOperatorService
{
  Task<PaginationDto<OperatorDto>> GetPaginationWithLocationIdAsync(int location, int Page, int PageSize);
  Task<OperatorDto> CreateAsync(CreateOperatorDto dto);
  Task<OperatorDto> UpdateAsync(UpdateOperatorDto dto);
  Task<OperatorDto> DeleteByIdAsync(int id);
}
