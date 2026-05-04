using System;
using Core.Application.Interfaces;
using Core.Domain.Constants;
using Core.Domain.Entities;
using Core.Domain.Events;

namespace Core.Application.Handlers;

public sealed class DeviceUpdatedIpEventHandler(IDeviceRepository repo) : IRabbitMqHandler<UpdateDeviceIpEvent>
{
       public string Exchange => MessageConstants.Device.EXCHANGE;
      public string RoutingKey => MessageConstants.Device.DEVICE_UPDATED_IP;

      public async Task HandleAsync(UpdateDeviceIpEvent Message, CancellationToken ct = default)
      {
            Console.WriteLine(Message.Mac);
            await repo.UpdateIpAsync(Message.Mac,Message.Ip);
      }
}

