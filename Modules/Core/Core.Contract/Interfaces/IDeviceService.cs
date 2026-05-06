
using Core.Contract.DTOs;

namespace Core.Application.Interfaces;

public interface IDeviceService : IBaseService<DeviceDto, CreateDeviceDto, UpdateDeviceDto>
{
      Task<BaseDto> GetIdReportAsync();
}
