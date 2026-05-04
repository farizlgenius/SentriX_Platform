using System;
using Core.Application.Interfaces;
using Core.Domain.Constants;
using Core.Domain.Events;

namespace Core.Application.Handlers;

public sealed class DeviceUpdatedPortEventHandler(IDeviceRepository repo) : IRabbitMqHandler<UpdateDevicePortEvent>
{
       public string Exchange => MessageConstants.Device.EXCHANGE;
      public string RoutingKey => MessageConstants.Device.DEVICE_UPDATED_PORT;

      public async Task HandleAsync(UpdateDevicePortEvent Message, CancellationToken ct = default)
      {
            Console.WriteLine(Message.Mac);
            await repo.UpdatePortAsync(Message.Mac,Message.Port);
      }
}
