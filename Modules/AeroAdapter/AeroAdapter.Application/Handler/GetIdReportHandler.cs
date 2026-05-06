using System;
using AeroAdapter.Application.DTOs;
using AeroAdapter.Application.Interfaces;
using AeroAdapter.Application.Memories;
using AeroAdapter.Domain.Events;
using Sentrix.Contract.Messaging.Constants;
using Sentrix.Contract.UiNotification.Constants;
using Sentrix.Contract.UiNotification.DTOS;

namespace AeroAdapter.Application.Handler;

public sealed class GetIdReportEventHandler(IMessagePublisher publisher,IdReports id) : IRabbitMqHandler<GetIdReportEvent>
{
      public string Exchange => RabbitMqConstants.Device.EXCHANGE;

      public string RoutingKey => RabbitMqConstants.Device.IDREPORT;

      public async Task HandleAsync(GetIdReportEvent message, CancellationToken ct)
      {
            UiMessage payload = new UiMessage();
            payload.Topic = UiTopic.IDREPORT;
            payload.Payload = id.GetIdReport();
            await publisher.PublishAsync(RabbitMqConstants.UI.EXCHANGE,RabbitMqConstants.UI.IDREPORT,payload);
      }
}
