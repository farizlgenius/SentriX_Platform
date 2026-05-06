using System;
using Core.Domain.Attributes;
using Core.Domain.Interfaces;

namespace Core.Domain.Events;

[Exchange("transction.exchange")]
[RoutingKey("transaction.create")]
public sealed record TransactionEvent : IRabbitMqEvent
{

}
