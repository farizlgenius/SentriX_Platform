using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Infrastructure.Persistence.Entities;

public class BaseEntity
{
  [Key]
  public int id { get; set; }
  public string name { get; set; } = string.Empty;
  public int location_id { get; set; }
  public DateTime created_at { get; set; } 
  public DateTime updated_at { get; set; } 
  public bool is_active { get; set; } = true;

  public BaseEntity() { }

  public void Disabled()
  {
    this.is_active = false;
  }

  public void Enabled()
  {
    this.is_active = true;
  }
}
