using System;

namespace Core.Infrastructure.Persistence.Entities;

public sealed class CardFormat : BaseEntity
{

  public CardFormat() { }
  public CardFormat(Domain.Entities.CardFormat domain)
  {
    this.id = domain.Id;
    this.name = domain.Name;
    this.location_id = domain.LocationId;
    this.created_at = DateTime.UtcNow;
    this.updated_at = DateTime.UtcNow;
  }


  public void Update(Domain.Entities.CardFormat domain)
  {
    this.name = domain.Name;
    this.location_id = domain.LocationId;
    this.updated_at = DateTime.UtcNow;
  }

}
