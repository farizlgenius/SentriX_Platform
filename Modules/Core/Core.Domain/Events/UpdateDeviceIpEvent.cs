using System;
using Core.Domain.Attributes;
using Core.Domain.Interfaces;

namespace Core.Domain.Events;

[Exchange("device.exchange")]
[RoutingKey("device.updated.ip")]
public sealed record UpdateDeviceIpEvent(
      string Mac,
      string Ip
) : IRabbitMqEvent;

