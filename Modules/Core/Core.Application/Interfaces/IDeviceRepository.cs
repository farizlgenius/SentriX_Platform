using System;
using Core.Contract.DTOs;
using Core.Domain.Entities;

namespace Core.Application.Interfaces;

public interface IDeviceRepository : IBaseRepository<DeviceDto, Device>
{
  Task<bool> IsAnyMacAsync(string Mac);
  Task<bool> IsAnyMacExceptIdAsync(string Mac, int Id);
  Task<bool> IsAnySerialAsync(string Serial);
  Task<bool> IsAnySerialExceptIdAsync(string Serial, int Id);
  Task<DeviceDto> UpdateIpAsync(string Mac,string Ip);
  Task<DeviceDto> UpdatePortAsync(string Mac,int Port);

}
