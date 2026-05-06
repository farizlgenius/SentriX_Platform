using System;
using Core.Infrastructure.Helpers;
using Core.Infrastructure.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Core.Infrastructure.Worker;

public sealed class RabbitMqWorker(IServiceScopeFactory scopeFactory) : BackgroundService
{
      protected async override Task ExecuteAsync(CancellationToken ct)
      {
            while (!ct.IsCancellationRequested)
            {
                  using var scope = scopeFactory.CreateScope();
                  var listener = scope.ServiceProvider.GetRequiredService<RabbitMqListener>();

                  await listener.StartAsync(ct);

                  await Task.Delay(Timeout.Infinite, ct);

            }
      }
}
