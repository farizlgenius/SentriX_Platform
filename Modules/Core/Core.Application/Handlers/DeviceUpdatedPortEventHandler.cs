using System;
using Core.Application.Interfaces;
using Core.Domain.Constants;
using Core.Domain.Events;
using Sentrix.Contract.Messaging.Constants;

namespace Core.Application.Handlers;

public sealed class DeviceUpdatedPortEventHandler(IDeviceRepository repo) : IRabbitMqHandler<UpdateDevicePortEvent>
{
       public string Exchange => RabbitMqConstants.Device.EXCHANGE;
      public string RoutingKey => RabbitMqConstants.Device.UPDATED_PORT;

      public async Task HandleAsync(UpdateDevicePortEvent Message, CancellationToken ct = default)
      {
            Console.WriteLine(Message.Mac);
            await repo.UpdatePortAsync(Message.Mac,Message.Port);
      }
}
