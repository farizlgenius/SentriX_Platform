using System;

namespace Core.Infrastructure.Persistence.Entities;

public sealed class Outbox : BaseEntity
{
  public string type { get; set; } = string.Empty;
  public string payload { get; set; } = string.Empty;
  public DateTime? processed_at { get; set; }

  public Outbox() { }
  public Outbox(string type, string payload)
  {
    this.type = type;
    this.payload = payload;
  }

}
