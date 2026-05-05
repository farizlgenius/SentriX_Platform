using System;
using Core.Api.Middlewares;
using Core.Application.Handlers;
using Core.Application.Interfaces;
using Core.Application.Services;
using Core.Domain.Interfaces;
using Core.Infrastructure.Messaging;
using Core.Infrastructure.Publisher;
using Core.Infrastructure.Repositories;
using Core.Infrastructure.Worker;
using Scrutor;

namespace Core.Api.Settings;

public class DISetting
{
  public static void DependencyInjectionSetting(WebApplicationBuilder builder)
  {
    // ==========================
    // Adding Repository
    // ==========================
    builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
    builder.Services.AddScoped<ICardFormatRepository, CardFormatRepository>();



    // ==========================
    // Adding Service
    // ==========================
    builder.Services.AddScoped<IDeviceService, DeviceService>();
    builder.Services.AddScoped<ICardFormatService, CardFormatService>();
    builder.Services.AddScoped<IBrokerService,BrokerService>();


    // ==========================
    // Custom Service
    // ==========================
    builder.Services.AddTransient<GlobalExceptionMiddleware>();
    builder.Services.AddScoped<IMessagePublisher, RabbitMqEventPublisher>();
    builder.Services.AddSingleton<IRabbitMqFactory, RabbitMqFactory>();

    // ==========================
    // Rabbit MQ
    // ==========================
    builder.Services.AddHostedService<RabbitMqWorker>();
    builder.Services.AddSingleton<RabbitMqListener>();
    builder.Services.AddSingleton<RabbitMqRouter>();
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
