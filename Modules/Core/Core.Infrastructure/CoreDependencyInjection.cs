using System;
using Core.Application.Interfaces;
using Core.Application.Services;
using Core.Infrastructure.Persistence;
using Core.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure;

public static class CoreDependencyInjection
{

       public static IServiceCollection AddCoreModule(
        this IServiceCollection services,
        IConfiguration configuration)
      {
            // ==========================
            // Adding Repository
            // ==========================
            
            services.AddScoped<IDeviceRepository, DeviceRepository>();


            // ==========================
            // Adding Service
            // ==========================
            
            services.AddScoped<IDeviceService, DeviceService>();
            
            
            // ==========================
            // Database
            // ==========================
            services.AddDbContext<CoreDbContext>(options =>
                options.UseNpgsql(
                configuration.GetConnectionString("PostgresConnection"),
                npgsqlOptions => npgsqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                ));

            return services;
      }

}
