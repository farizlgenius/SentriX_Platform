using System;
using System.Text.Json;
using Core.Application.Interfaces;
using Core.Domain.Entities;
using Core.Infrastructure.Messaging;
using RabbitMQ.Client;

namespace Core.Infrastructure.Publisher;

public sealed class RabbitMqEventPublisher : IMessagePublisher
{
  private readonly IRabbitMqFactory _connection;
  public RabbitMqEventPublisher(IRabbitMqFactory connection, IRabbitMqOptions options)
  {
    _connection = connection;
  }
  public async Task PublishAsync<T>(string Exchange,string RoutingKey,T Message, CancellationToken ct = default)
  {
    var connection = await _connection.GetConnectionAsync(ct);
    var channel = await connection.CreateChannelAsync(cancellationToken: ct);

    // Declare Exchage 
    await channel.ExchangeDeclareAsync(
      Exchange,
      ExchangeType.Topic,
      durable: true,
      cancellationToken: ct
    );


    var body = JsonSerializer.SerializeToUtf8Bytes(Message);

    await channel.BasicPublishAsync(
      exchange: Exchange,
      routingKey: RoutingKey,
      body: body,
      cancellationToken: ct
    );
  }

}
