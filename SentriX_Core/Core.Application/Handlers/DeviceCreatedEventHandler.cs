using System;
using Core.Application.DTOs;
using Core.Application.Interfaces;
using Core.Domain.Constants;
using Core.Domain.Entities;
using Core.Domain.Events;

namespace Core.Application.Handlers;


public sealed class DeviceCreatedEventHandler(IDeviceRepository repo) : IRabbitMqHandler<CreateDeviceEvent>
{
      public string Exchange => MessageConstants.Device.EXCHANGE;
      public string RoutingKey => MessageConstants.Device.DEVICE_CREATED;

      public async Task HandleAsync(CreateDeviceEvent Message, CancellationToken ct = default)
      {
            Console.WriteLine(Message.Name);
            var domain = new Device(
                  0,
                  string.Empty,
                  Message.SerialNumber,
                  Message.Mac,
                  Message.Ip,
                  Message.Port,
                  Message.Fw,
                  Message.Type,
                  Message.Status,
                  Message.SyncedAt,
                  Message.LocationId
                  );
            await repo.CreateAsync(domain);
      }
}
