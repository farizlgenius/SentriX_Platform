using System;

using Core.Application.Interfaces;
using Core.Contract.DTOs;
using Core.Domain.Constants;
using Core.Domain.Entities;
using Core.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Repositories;

public sealed class CardFormatRepository(CoreDbContext context) : ICardFormatRepository
{
  public async Task<CardFormatDto> CreateAsync(CardFormat domain)
  {
    var data = await context.CardFormats.AddAsync(
      new Persistence.Entities.CardFormat(domain)
    );

    var save = await context.SaveChangesAsync();

    if (data == null || save <= 0)
      throw new Exception(DbExceptionMessage.SaveRecordUnsuccessful);

    return new CardFormatDto(data.Entity.id, data.Entity.name, data.Entity.location_id);
  }

  public async Task<CardFormatDto> DeleteByIdAsync(int id)
  {
    var entity = await context.CardFormats.OrderBy(c => c.id).Where(c => c.id == id).FirstOrDefaultAsync();
    if (entity == null)
      throw new Exception(DbExceptionMessage.RecordNotFound);

    var data = context.CardFormats.Remove(entity);
    var save = await context.SaveChangesAsync();

    if (data == null || save <= 0)
      throw new Exception(DbExceptionMessage.SaveRecordUnsuccessful);

    return new CardFormatDto(data.Entity.id, data.Entity.name, data.Entity.location_id);
  }

  public async Task<PaginationDto<CardFormatDto>> GetPaginationByLocationIdAsync(int location, int Page, int PageSize)
  {
    var query = context.CardFormats.AsNoTracking().OrderBy(c => c.id).Where(c => c.location_id == location).AsQueryable();
    var items = await query.Skip((Page - 1) * PageSize).Take(PageSize).Select(c => new CardFormatDto(c.id, c.name, c.location_id)).ToListAsync();
    var totalItems = await query.CountAsync();

    return new PaginationDto<CardFormatDto>(Page, PageSize, totalItems,
    (int)Math.Ceiling(totalItems / (double)PageSize)
    , items);
  }

  public async Task<bool> IsAnyIdAsync(int Id)
  {
    return await context.CardFormats.AsNoTracking().Where(c => c.id == Id).AnyAsync();
  }

  public async Task<bool> IsAnyNameExceptIdAsync(string Name, int Id)
  {
    return await context.CardFormats.AsNoTracking().Where(c => c.name == Name && c.id != Id).AnyAsync();
  }

  public async Task<bool> IsAnyNameExceptLocationIdAsync(string Name, int LocationId)
  {
    return await context.CardFormats.AsNoTracking().Where(c => c.name == Name && c.location_id != LocationId).AnyAsync();
  }


  public async Task<CardFormatDto> UpdateAsync(CardFormat domain)
  {
    var entity = await context.CardFormats.OrderBy(c => c.id).Where(c => c.id == domain.Id).FirstOrDefaultAsync();
    if (entity == null)
      throw new Exception(DbExceptionMessage.RecordNotFound);

    entity.Update(domain);

    var data = context.CardFormats.Update(entity);
    var save = await context.SaveChangesAsync();

    if (data == null || save <= 0)
      throw new Exception(DbExceptionMessage.SaveRecordUnsuccessful);

    return new CardFormatDto(data.Entity.id, data.Entity.name, data.Entity.location_id);
  }
}
