

namespace Core.Contract.DTOs;

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
