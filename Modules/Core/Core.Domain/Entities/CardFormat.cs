using System;
using Core.Domain.Helpers;

namespace Core.Domain.Entities;

public sealed class CardFormat
{
  public int Id { get; private set; }
  public string Name { get; private set; } = string.Empty;
  public int LocationId { get; private set; }

  public CardFormat(int id, string name, int locationId)
  {
    ValidationHelper.ValidateNotMinus(id, nameof(Id));
    ValidationHelper.ValidateNotNullOrEmpty(name, nameof(Name));
    ValidationHelper.ValidateNotMinus(locationId, nameof(LocationId));
    this.Id = id;
    this.Name = name;
    this.LocationId = locationId;
  }

}
