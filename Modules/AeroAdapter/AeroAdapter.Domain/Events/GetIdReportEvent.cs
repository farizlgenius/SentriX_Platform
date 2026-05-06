using AeroAdapter.Domain.Attributes;
using AeroAdapter.Domain.Entities;

namespace AeroAdapter.Domain.Events;

[Exchange("device.exchange")]
[RoutingKey("device.idreport")]
public sealed record GetIdReportEvent() : IRabbitMqEvent;
