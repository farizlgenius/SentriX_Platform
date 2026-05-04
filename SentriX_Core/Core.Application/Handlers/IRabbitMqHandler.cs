using System;
using Core.Domain.Interfaces;

namespace Core.Application.Handlers;

public interface IRabbitMqHandler<TMessage>
    where TMessage : IRabbitMqEvent
{
    string Exchange { get; }
    string RoutingKey { get; }
    Task HandleAsync(TMessage message, CancellationToken ct);
}
