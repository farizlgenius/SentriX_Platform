using System;
using Core.Application.Interfaces;
using RabbitMQ.Client;

namespace Core.Infrastructure.Messaging;

public class RabbitMqFactory : IRabbitMqFactory
{
  private readonly ConnectionFactory _factory;
  public RabbitMqFactory(IRabbitMqOptions options)
  {
    _factory = new ConnectionFactory
    {
      HostName = options.Host,
      UserName = options.Username,
      Password = options.Password,
      Port = options.Port
    };
  }

  public async Task<IConnection> GetConnectionAsync(CancellationToken ct) => await _factory.CreateConnectionAsync();
}
