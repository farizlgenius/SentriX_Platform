using System;

namespace Core.Infrastructure.Messaging;

public interface IRabbitMqHandlerWrapper
{
    string Exchange { get; }
    string RoutingKey { get; }

    Task HandleAsync(byte[] body, IServiceProvider sp, CancellationToken ct);
}