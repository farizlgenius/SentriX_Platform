using System;
using System.Reflection;
using AeroAdapter.Application.Handler;
using AeroAdapter.Domain.Attributes;
using AeroAdapter.Domain.Events;
using AeroAdapter.Domain.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace AeroAdapter.Infrastructure.Messaging;

public sealed class RabbitMqHandlerWrapper<TMessage> : IRabbitMqHandlerWrapper 
    where TMessage : IRabbitMqEvent
{
    public string Exchange { get; }
    public string RoutingKey { get; }

    public RabbitMqHandlerWrapper()
    {
        var attrExchange = typeof(TMessage)
            .GetCustomAttribute<ExchangeAttribute>()!;
        var attrRouting = typeof(TMessage)
            .GetCustomAttribute<RoutingKeyAttribute>()!;

        Exchange = attrExchange.Name;
        RoutingKey = attrRouting.Key;
    }

    public async Task HandleAsync(byte[] body, IServiceProvider sp, CancellationToken ct)
    {
        using var scope = sp.CreateScope();

        var handler = scope.ServiceProvider
            .GetRequiredService<IRabbitMqHandler<TMessage>>();

        var message = MessageHelper.Deserialize<TMessage>(body);
        await handler.HandleAsync(message, ct);
    }
}
