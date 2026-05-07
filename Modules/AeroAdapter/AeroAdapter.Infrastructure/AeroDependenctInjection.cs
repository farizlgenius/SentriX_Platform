using System;
using System.Threading.Channels;
using AeroAdapter.Application.Interfaces;
using AeroAdapter.Application.Memories;
using AeroAdapter.Application.Services;
using AeroAdapter.Infrastructure.Listener;
using AeroAdapter.Infrastructure.Persistences;
using AeroAdapter.Infrastructure.Repositories;
using AeroAdapter.Infrastructure.Writer;
using Application.Contracts.GeneratedDtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AeroAdapter.Infrastructure;

public static class AeroDependenctInjection
{
      public static IServiceCollection AddAeroModule(
        this IServiceCollection services,
        IConfiguration configuration)
      {
            // ==========================
            // Adding Repository
            // ==========================
            
            services.AddScoped<IScpRepository, ScpRepository>();
            services.AddScoped<IWriterRepository, WriterRepository>();
            services.AddScoped<IMpRepository, MpRepository>();

            // ==========================
            // Adding Service
            // ==========================
            
            services.AddScoped<IScpService, ScpService>();
            

            // ==========================
            // Writer Command
            // ==========================
            services.AddScoped<IDriverWriter, DriverWriter>();
            services.AddScoped<IScpWriter, ScpWriter>();
            services.AddScoped<ISioWriter, SioWriter>();
            services.AddScoped<IMpWriter, MpWriter>();
            services.AddScoped<IObjectMapper, DeepReflectionMapper>();
            services.AddSingleton<AeroMessageListener>();
           services.AddSingleton<IdReports>();
            services.AddHostedService<AeroAdapter.Infrastructure.Worker.ScpReplyWorker>();


            // ==========================
            // Worker
            // ==========================
            services.AddSingleton(
                Channel.CreateBounded<SCPReplyMessageDto>(
                 new BoundedChannelOptions(10_000)
                    {
                        FullMode = BoundedChannelFullMode.DropOldest,
                        SingleReader = true,
                        SingleWriter = false
                    }
                )
             );
            
            // ==========================
            // Database
            // ==========================
            services.AddDbContext<AeroDbContext>(options =>
                options.UseNpgsql(
                configuration.GetConnectionString("PostgresConnection"),
                npgsqlOptions => npgsqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                ));

            return services;
      }

}
