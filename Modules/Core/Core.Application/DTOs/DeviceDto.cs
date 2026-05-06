using System;
using Core.Domain.Enums;

namespace Core.Application.DTOs;

public record DeviceDto(
      int Id, 
      string Name, 
      string SerialNumber, 
      string Mac,
      string Ip, 
      int Port,
      string Fw,
      string Type, 
      DeviceSyncStatus Status,
      DateTime SyncedAt,
      int LocationId
      );
