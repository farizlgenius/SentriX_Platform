using System;
using Core.Application.DTOs;
using Core.Application.Exceptions;
using Core.Application.Interfaces;
using Core.Domain.Constants;

namespace Core.Application.Services;

public sealed class CardFormatService(ICardFormatRepository repo) : ICardFormatService
{
  public async Task<CardFormatDto> CreateAsync(CreateCardFormatDto dto)
  {
    if (string.IsNullOrWhiteSpace(dto.Name))
      throw new BadRequestException(ResponseMessage.NameEmpty);

    if (await repo.IsAnyNameExceptLocationIdAsync(dto.Name, dto.LocationId))
      throw new BadRequestException(ResponseMessage.DuplicatedName);

    // Check for location existence

    var domain = new Domain.Entities.CardFormat(0, dto.Name, dto.LocationId);
    return await repo.CreateAsync(domain);
  }

  public Task<CardFormatDto> DeleteByIdAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<PaginationDto<CardFormatDto>> GetPaginationByLocationIdAsync(int location, int Page, int PageSize)
  {
    throw new NotImplementedException();
  }

  public Task<CardFormatDto> UpdateAsync(UpdateCardFormatDto dto)
  {
    throw new NotImplementedException();
  }
}
