using System;
using RabbitMQ.Client;

namespace Core.Infrastructure.Messaging;

public interface IRabbitMqFactory
{
  Task<IConnection> GetConnectionAsync(CancellationToken ct = default);
}

