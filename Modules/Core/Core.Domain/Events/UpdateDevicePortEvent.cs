using System;
using Core.Domain.Attributes;
using Core.Domain.Interfaces;

namespace Core.Domain.Events;


[Exchange("device.exchange")]
[RoutingKey("device.updated.port")]
public sealed record UpdateDevicePortEvent(
      string Mac,
      int Port
) : IRabbitMqEvent;