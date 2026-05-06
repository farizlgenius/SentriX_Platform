using System;
using System.Reflection;
using Core.Application.Handlers;
using Core.Domain.Attributes;
using Core.Domain.Interfaces;
using Core.Infrastructure.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure.Messaging;

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


