using System;
using AeroAdapter.Domain.Events;

namespace AeroAdapter.Application.Handler;

public interface IRabbitMqHandler<TMessage>
    where TMessage : IRabbitMqEvent
{
    string Exchange { get; }
    string RoutingKey { get; }
    Task HandleAsync(TMessage message, CancellationToken ct);
}