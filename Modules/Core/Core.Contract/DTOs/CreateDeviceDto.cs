using SentriX.BuildingBlock.Enums;

namespace Core.Contract.DTOs;

public record CreateDeviceDto(
      string Name,
      int ComponentId, 
      string Mac,
      string SerialNumber, 
      string Ip,
      int Port,
      string Fw,
      string Type,
      DateTime SyncedAt, 
      string Status,
      int LocationId
      ) ;
