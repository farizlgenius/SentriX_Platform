using System;
using Core.Infrastructure.Persistence;
using Core.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Repositories;

public class HelperRepository<T>(AppDbContext context) where T : Persistence.Entities.BaseEntity
{
  protected readonly AppDbContext Context = context;
  public async Task<bool> IsAnyNameExceptIdAsync(string Name, int Id)
  {
    return await Context.Set<T>().AsNoTracking().AnyAsync(x => x.name.Equals(Name) && x.id != Id);
  }

  public async Task<bool> IsAnyNameExceptLocationIdAsync(string Name, int LocationId)
  {
    return await Context.Set<T>().AsNoTracking().AnyAsync(x => x.name.Equals(Name) && x.location_id != LocationId);
  }
}
