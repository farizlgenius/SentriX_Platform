using System;
using System.Security.Cryptography.X509Certificates;
using Core.Domain.Enums;
using Core.Domain.Interfaces;
using Core.Domain.Attributes;

namespace Core.Domain.Events;

[Exchange("device.exchange")]
[RoutingKey("device.created")]
public sealed class CreateDeviceEvent : IRabbitMqEvent
{
      public string Name {get; set;} = string.Empty;
      public int ComponentId {get; set;}
      public string Mac {get; set;} = string.Empty;
      public string SerialNumber {get; set;} = string.Empty;
      public string Ip {get; set;} = string.Empty;
      public int Port {get; set;}
      public string Fw {get; set;} = string.Empty;
      public string Type {get; set;} = string.Empty;
      public DateTime SyncedAt {get; set;}
      public DeviceSyncStatus Status {get; set;}
      public int LocationId {get; set;}

      public CreateDeviceEvent(){}

      public CreateDeviceEvent(string name, int componentId, string mac, string serialNumber, string ip, int port, string fw, string type, DateTime syncedAt, DeviceSyncStatus status, int locationId)
      {
            Name = name;
            ComponentId = componentId;
            Mac = mac;
            SerialNumber = serialNumber;
            Ip = ip;
            Port = port;
            Fw = fw;
            Type = type;
            SyncedAt = syncedAt;
            Status = status;
            LocationId = locationId;
      }
}
