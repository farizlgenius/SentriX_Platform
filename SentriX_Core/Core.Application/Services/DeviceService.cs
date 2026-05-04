using System;
using System.Diagnostics;
using Core.Application.DTOs;
using Core.Application.Exceptions;
using Core.Application.Interfaces;
using Core.Domain.Constants;
using Core.Domain.Entities;
using Core.Domain.Enums;

namespace Core.Application.Services;

public class DeviceService(IDeviceRepository repo) : IDeviceService
{
  public async Task<DeviceDto> CreateAsync(CreateDeviceDto dto)
  {
    if (string.IsNullOrWhiteSpace(dto.Name))
      throw new BadRequestException(ResponseMessage.NameEmpty);

    if (await repo.IsAnyNameExceptLocationIdAsync(dto.Name, dto.LocationId))
      throw new BadRequestException(ResponseMessage.DuplicatedName);

    if (await repo.IsAnyMacAsync(dto.Mac))
      throw new BadRequestException(ResponseMessage.DuplicatedMac);

    if (await repo.IsAnySerialAsync(dto.SerialNumber))
      throw new BadRequestException(ResponseMessage.DuplicatedSerialNumber);

    // Check Location Id is that exists

    var domain = new Device(
      0,
      dto.Name,
      dto.SerialNumber,
      dto.Mac,
      dto.Ip,
      dto.Port,
      dto.Fw,
      dto.Type,
      dto.Status,
      dto.SyncedAt,
      dto.LocationId
      );

    return await repo.CreateAsync(domain);
  }

  public async Task<DeviceDto> DeleteByIdAsync(int id)
  {
    if (!await repo.IsAnyIdAsync(id))
      throw new BadRequestException(ResponseMessage.RecordNotFound);

    return await repo.DeleteByIdAsync(id);
  }

  public async Task<PaginationDto<DeviceDto>> GetPaginationByLocationIdAsync(int location, int Page, int PageSize)
  {
    var res = await repo.GetPaginationByLocationIdAsync(location, Page, PageSize);
    return res;
  }

  public async Task<DeviceDto> UpdateAsync(UpdateDeviceDto dto)
  {
    if (!await repo.IsAnyIdAsync(dto.Id))
      throw new BadRequestException(ResponseMessage.RecordNotFound);

    if (string.IsNullOrWhiteSpace(dto.Name))
      throw new BadRequestException(ResponseMessage.NameEmpty);

    if (await repo.IsAnyMacExceptIdAsync(dto.Mac, dto.Id))
      throw new BadRequestException(ResponseMessage.DuplicatedMac);

    if (await repo.IsAnySerialExceptIdAsync(dto.SerialNumber, dto.Id))
      throw new BadRequestException(ResponseMessage.DuplicatedSerialNumber);

    var domain = new Device(
      dto.Id,
      dto.Name,
      dto.SerialNumber,
      dto.Mac,
      dto.Ip,
      dto.Port,
      dto.Fw,
      dto.Type,
      dto.Status,
      dto.SyncedAt,
      dto.LocationId
      );



    return await repo.UpdateAsync(domain);
  }
}
