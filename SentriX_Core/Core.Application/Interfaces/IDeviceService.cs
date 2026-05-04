using System;
using Core.Application.DTOs;

namespace Core.Application.Interfaces;

public interface IDeviceService : IBaseService<DeviceDto, CreateDeviceDto, UpdateDeviceDto>
{

}
