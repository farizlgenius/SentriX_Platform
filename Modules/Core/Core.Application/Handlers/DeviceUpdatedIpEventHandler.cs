using System;
using Core.Application.Interfaces;
using Core.Domain.Constants;
using Core.Domain.Entities;
using Core.Domain.Events;
using Sentrix.Contract.Messaging.Constants;

namespace Core.Application.Handlers;

public sealed class DeviceUpdatedIpEventHandler(IDeviceRepository repo) : IRabbitMqHandler<UpdateDeviceIpEvent>
{
       public string Exchange => RabbitMqConstants.Device.EXCHANGE;
      public string RoutingKey => RabbitMqConstants.Device.UPDATED_IP;

      public async Task HandleAsync(UpdateDeviceIpEvent Message, CancellationToken ct = default)
      {
            Console.WriteLine(Message.Mac);
            await repo.UpdateIpAsync(Message.Mac,Message.Ip);
      }
}

