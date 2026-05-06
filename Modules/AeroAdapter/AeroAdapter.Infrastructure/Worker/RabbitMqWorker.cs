using System;
using AeroAdapter.Domain.Entities;
using AeroAdapter.Domain.Helpers;
using AeroAdapter.Infrastructure.Helpers;
using AeroAdapter.Infrastructure.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace AeroAdapter.Infrastructure.Worker;

public sealed class RabbitMqWorker(IServiceScopeFactory scopeFactory) : BackgroundService
{
      protected async override Task ExecuteAsync(CancellationToken ct)
      {
            while (!ct.IsCancellationRequested)
            {
                  // Message Broker
                  using var scope = scopeFactory.CreateScope();
                  var listener = scope.ServiceProvider.GetRequiredService<RabbitMqListener>();
                  
                  await listener.StartAsync(ct);

                  // keep worker alive forever
                  await Task.Delay(Timeout.Infinite, ct);
            }
      }
}
