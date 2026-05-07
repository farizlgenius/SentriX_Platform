using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notifier.Infrastructure.Services;
using UINotifier.Contract.Interfaces;

namespace Notifier.Infrastructure;

public static class NotifierDependencyInjection
{
      public static IServiceCollection AddNotifyModule(
        this IServiceCollection services,
        IConfiguration configuration)
      {
            // ==========================
            // Adding Repository
            // ==========================
            
            services.AddScoped<INotifier, NotifierService>();

            return services;
      }

}
