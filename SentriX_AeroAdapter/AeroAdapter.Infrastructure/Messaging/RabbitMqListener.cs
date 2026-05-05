using System;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace AeroAdapter.Infrastructure.Messaging;


public sealed class RabbitMqListener
{
      private readonly IRabbitMqFactory _factory;
    private readonly RabbitMqRouter _router;
    private readonly IServiceProvider _provider;

    public RabbitMqListener(
        IRabbitMqFactory factory,
        RabbitMqRouter router,
        IServiceProvider provider)
    {
        _factory = factory;
        _router = router;
        _provider = provider;
    }

    public async Task StartAsync(CancellationToken ct)
    {
        var connection = await _factory.GetConnectionAsync();
        var channel = await connection.CreateChannelAsync();

        await channel.BasicQosAsync(0, 10, false);

        var subscriptions = _router.GetAllSubscriptions()
                                   .GroupBy(x => x.exchange);

        foreach (var exchangeGroup in subscriptions)
        {
            var exchange = exchangeGroup.Key;
            var queue = $"{exchange}.queue";

            await channel.ExchangeDeclareAsync(exchange, ExchangeType.Topic, true);
            await channel.QueueDeclareAsync(queue, true, false, false);

            foreach (var sub in exchangeGroup)
            {
                await channel.QueueBindAsync(queue, exchange, sub.routingKey);
            }

            await StartConsumer(channel, queue, exchange, ct);
        }
    }

    private async Task StartConsumer(
        IChannel channel,
        string queue,
        string exchange,
        CancellationToken ct)
    {
        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (_, ea) =>
        {
            using var scope = _provider.CreateScope();

            try
            {
                await _router.RouteAsync(
                    exchange,
                    ea.RoutingKey,
                    ea.Body.ToArray(),
                    scope.ServiceProvider,
                    ct);

                await channel.BasicAckAsync(ea.DeliveryTag, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                await channel.BasicNackAsync(ea.DeliveryTag, false, false);
            }
        };

        await channel.BasicConsumeAsync(queue, false, consumer);
    }
}
