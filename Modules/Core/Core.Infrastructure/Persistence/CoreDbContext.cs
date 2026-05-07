using System;
using Core.Domain.Entities;
using Core.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Persistence;

public sealed class CoreDbContext(DbContextOptions<CoreDbContext> options) : DbContext(options)
{
  public const string Schema = "Core";
  public DbSet<Persistence.Entities.Device> Devices { get; set; }
  public DbSet<Persistence.Entities.CardFormat> CardFormats { get; set; }
  public DbSet<Persistence.Entities.Outbox> Outboxes { get; set; }
  public DbSet<Persistence.Entities.Feature> Features { get; set; }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.HasDefaultSchema(Schema);

    modelBuilder.Entity<Infrastructure.Persistence.Entities.Feature>().HasData(
    new Infrastructure.Persistence.Entities.Feature { id = 1, name = "dashboard", },
    new Infrastructure.Persistence.Entities.Feature { id = 2, name = "events", },
    new Infrastructure.Persistence.Entities.Feature { id = 3, name = "location", },
    new Infrastructure.Persistence.Entities.Feature { id = 4, name = "alert", },
    new Infrastructure.Persistence.Entities.Feature { id = 5, name = "operator", },
    new Infrastructure.Persistence.Entities.Feature { id = 6, name = "device", },
    new Infrastructure.Persistence.Entities.Feature { id = 7, name = "control", },
    new Infrastructure.Persistence.Entities.Feature { id = 8, name = "monitor", },
    new Infrastructure.Persistence.Entities.Feature { id = 9, name = "monitorgroup", },
    new Infrastructure.Persistence.Entities.Feature { id = 10, name = "acr", },
    new Infrastructure.Persistence.Entities.Feature { id = 11, name = "user", },
    new Infrastructure.Persistence.Entities.Feature { id = 12, name = "group", },
    new Infrastructure.Persistence.Entities.Feature { id = 13, name = "area", },
    new Infrastructure.Persistence.Entities.Feature { id = 14, name = "time", },
    new Infrastructure.Persistence.Entities.Feature { id = 15, name = "trigger", },
    new Infrastructure.Persistence.Entities.Feature { id = 16, name = "map", },
    new Infrastructure.Persistence.Entities.Feature { id = 17, name = "report", },
    new Infrastructure.Persistence.Entities.Feature { id = 18, name = "setting", },
    new Infrastructure.Persistence.Entities.Feature { id = 19, name = "tools", }
    );

  }
}
