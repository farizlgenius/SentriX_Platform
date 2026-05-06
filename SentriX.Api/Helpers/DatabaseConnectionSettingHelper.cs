using System;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace SentriX.Api.Helpers;

public class DatabaseConnectionSettingHelper
{
  public static void DatabaseConnectionHelper(WebApplicationBuilder builder)
  {
    builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                builder.Configuration.GetConnectionString("PostgresConnection"),
                npgsqlOptions => npgsqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                ));
  }
}
