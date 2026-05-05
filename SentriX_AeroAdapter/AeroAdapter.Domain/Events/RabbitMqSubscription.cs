using System;

namespace AeroAdapter.Domain.Events;

public sealed record RabbitMqSubscription(
      string exchange,
      string queue,
      string routingKey
);

