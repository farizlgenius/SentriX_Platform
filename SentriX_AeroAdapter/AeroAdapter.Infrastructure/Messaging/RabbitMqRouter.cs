using System;
using AeroAdapter.Domain.Events;

namespace AeroAdapter.Infrastructure.Messaging;

public sealed class RabbitMqRouter
{
      private readonly Dictionary<SubscriptionKey,IRabbitMqHandlerWrapper> _handlers;

      public RabbitMqRouter(IEnumerable<IRabbitMqHandlerWrapper> handlers)
      {
            _handlers = handlers.ToDictionary(
                  h => new SubscriptionKey(h.Exchange,h.RoutingKey),
                  h => h
            );
      }

      public async Task RouteAsync(
            string exchange,
            string routingKey,
            byte[] body,
            IServiceProvider sp,
            CancellationToken ct
      )
      {
            var key = new SubscriptionKey(exchange,routingKey);

            if(!_handlers.TryGetValue(key,out var handler))
                  throw new Exception($"No handler for {exchange}:{routingKey}");

            await handler.HandleAsync(body,sp,ct);
      }

      public IEnumerable<RabbitMqSubscription> GetAllSubscriptions()
      {
            return _handlers.Keys.Select(k => 
                  new RabbitMqSubscription(
                        k.Exchange,
                        $"{k.Exchange}.queue",
                        k.RoutingKey
                        )
            );
      }
}

