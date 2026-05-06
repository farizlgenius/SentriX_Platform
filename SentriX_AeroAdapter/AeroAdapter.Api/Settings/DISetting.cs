using System;
using AeroAdapter.Api.Middlewares;
using AeroAdapter.Application.Handler;
using AeroAdapter.Application.Interfaces;
using AeroAdapter.Application.Memories;
using AeroAdapter.Application.Services;
using AeroAdapter.Domain.Events;
using AeroAdapter.Infrastructure.Listener;
using AeroAdapter.Infrastructure.Messaging;
using AeroAdapter.Infrastructure.Repositories;
using AeroAdapter.Infrastructure.Worker;
using AeroAdapter.Infrastructure.Writer;
using Scrutor;

namespace AeroAdapter.Api.Settings;

public class DISetting
{
      public static void DependencyInjectionSetting(WebApplicationBuilder builder)
      {
            // Others
            builder.Services.AddSingleton<IdReports>();

            // Repo
            builder.Services.AddScoped<IScpRepository, ScpRepository>();
            builder.Services.AddScoped<IWriterRepository, WriterRepository>();
            builder.Services.AddScoped<IMpRepository, MpRepository>();

            // Service
            builder.Services.AddScoped<IScpService, ScpService>();

            // Writer
            builder.Services.AddScoped<IDriverWriter, DriverWriter>();
            builder.Services.AddScoped<IScpWriter, ScpWriter>();
            builder.Services.AddScoped<ISioWriter, SioWriter>();
            builder.Services.AddScoped<IMpWriter, MpWriter>();
            builder.Services.AddScoped<IObjectMapper, DeepReflectionMapper>();
            builder.Services.AddSingleton<AeroMessageListener>();

            // Worker
            builder.Services.AddHostedService<AeroAdapter.Infrastructure.Worker.ScpReplyWorker>();
            builder.Services.AddHostedService<RabbitMqWorker>();

            // Middleware
            builder.Services.AddTransient<GlobalExceptionMiddleware>();

            // Message
            builder.Services.AddScoped<IMessagePublisher, RabbitMqMessagePublisher>();
            builder.Services.AddSingleton<RabbitMqListener>();

            // ==========================
            // Rabbit MQ
            // ==========================
            builder.Services.AddSingleton<RabbitMqRouter>();
             builder.Services.AddSingleton<IRabbitMqFactory,RabbitMqFactory>();
            builder.Services.Scan(scan => scan
            .FromAssemblies(
                typeof(IRabbitMqEvent).Assembly,          // Core.Domain
                typeof(IRabbitMqHandler<>).Assembly       // Core.Application (handlers live here)
            )
            .AddClasses(classes => classes.AssignableTo(typeof(IRabbitMqHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            // register wrapper for each handler
            builder.Services.AddSingleton<IEnumerable<IRabbitMqHandlerWrapper>>(_ =>
         {
               var wrappers = new List<IRabbitMqHandlerWrapper>();

               // 🔥 scan assemblies instead of asking DI
               var handlerTypes = AppDomain.CurrentDomain.GetAssemblies()
          .SelectMany(a => a.GetTypes())
          .Where(t => !t.IsAbstract && !t.IsInterface)
          .SelectMany(t => t.GetInterfaces()
              .Where(i => i.IsGenericType &&
                          i.GetGenericTypeDefinition() == typeof(IRabbitMqHandler<>))
              .Select(i => new { Handler = t, Interface = i }))
          .ToList();

               foreach (var h in handlerTypes)
               {
                     var messageType = h.Interface.GetGenericArguments()[0];
                     var wrapperType = typeof(RabbitMqHandlerWrapper<>).MakeGenericType(messageType);

                     var wrapper = (IRabbitMqHandlerWrapper)Activator.CreateInstance(wrapperType)!;
                     wrappers.Add(wrapper);
               }

               return wrappers;
         });
      }

}
