using System;

namespace AeroAdapter.Domain.Events;

public sealed record SubscriptionKey(string Exchange,string RoutingKey);