
using Core.Application.Interfaces;
using Core.Contract.DTOs;
using Core.Domain.Constants;
using Core.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Repositories;

public sealed class DeviceRepository(CoreDbContext context) : IDeviceRepository
{
  public async Task<DeviceDto> CreateAsync(Domain.Entities.Device domain)
  {
    var entity = new Persistence.Entities.Device(domain);
    var data = await context.Devices.AddAsync(entity);
    var save = await context.SaveChangesAsync();

    if (data == null || save <= 0)
      throw new Exception(DbExceptionMessage.SaveRecordUnsuccessful);

    return new DeviceDto(
      data.Entity.id,
      data.Entity.name,
      data.Entity.serial_number,
      data.Entity.mac,
      data.Entity.ip,
      data.Entity.port,
      data.Entity.fw,
      data.Entity.type,
      data.Entity.status,
      data.Entity.synced_at,
      data.Entity.location_id
      );
  }

  public async Task<DeviceDto> DeleteByIdAsync(int id)
  {
    var entity = await context.Devices.Where(d => d.id == id).FirstOrDefaultAsync();
    if (entity == null)
      throw new Exception(DbExceptionMessage.RecordNotFound);

    var data = context.Devices.Remove(entity);

    var save = await context.SaveChangesAsync();

    if (data == null || save <= 0)
      throw new Exception(DbExceptionMessage.SaveRecordUnsuccessful);

    return new DeviceDto(
      data.Entity.id,
      data.Entity.name,
      data.Entity.serial_number,
      data.Entity.mac,
      data.Entity.ip,
      data.Entity.port,
      data.Entity.fw,
      data.Entity.type,
      data.Entity.status,
      data.Entity.synced_at,
      data.Entity.location_id
      );


  }

  public async Task<PaginationDto<DeviceDto>> GetPaginationByLocationIdAsync(int location, int Page, int PageSize)
  {
    var query = context.Devices
    .AsNoTracking()
    .Where(x => x.location_id == location)
    .AsQueryable();

    var totalItems = await query.CountAsync();
    var items = await query.Select(d => new DeviceDto(
      d.id,
      d.name,
      d.serial_number,
      d.mac,
      d.ip,
      d.port,
      d.fw,
      d.type,
      d.status,
      d.synced_at,
      d.location_id
      )).ToListAsync();


    return new PaginationDto<DeviceDto>(
      Page,
      PageSize,
      totalItems,
      (int)Math.Ceiling(totalItems / (double)PageSize),
      items
    );
  }

  public async Task<bool> IsAnyIdAsync(int Id)
  {
    return await context.Devices.AsNoTracking().AnyAsync(x => x.id == Id);
  }

  public async Task<bool> IsAnyMacAsync(string Mac)
  {
    return await context.Devices.AsNoTracking().AnyAsync(x => x.mac.Equals(Mac));
  }

  public async Task<bool> IsAnyMacExceptIdAsync(string Mac, int Id)
  {
    return await context.Devices.AsNoTracking().AnyAsync(x => x.mac.Equals(Mac) && x.id != Id);
  }

  public async Task<bool> IsAnyNameExceptIdAsync(string Name, int Id)
  {
    return await context.Devices.AsNoTracking().AnyAsync(x => x.name.Equals(Name) && x.id != Id);
  }

  public async Task<bool> IsAnyNameExceptLocationIdAsync(string Name, int LocationId)
  {
    return await context.Devices.AsNoTracking().AnyAsync(x => x.name.Equals(Name) && x.location_id != LocationId);
  }

  public async Task<bool> IsAnySerialAsync(string Serial)
  {
    return await context.Devices.AsNoTracking().AnyAsync(x => x.serial_number.Equals(Serial));
  }

  public async Task<bool> IsAnySerialExceptIdAsync(string Serial, int Id)
  {
    return await context.Devices.AsNoTracking().AnyAsync(x => x.serial_number.Equals(Serial) && x.id != Id);
  }

  public async Task<DeviceDto> UpdateAsync(Domain.Entities.Device domain)
  {
    var entity = await context.Devices.Where(d => d.id == domain.Id).FirstOrDefaultAsync();
    if (entity == null)
      throw new Exception(DbExceptionMessage.RecordNotFound);

    entity.Update(domain);

    var data = context.Devices.Update(entity);

    var save = await context.SaveChangesAsync();

    if (data == null || save <= 0)
      throw new Exception(DbExceptionMessage.SaveRecordUnsuccessful);

    return new DeviceDto(
      data.Entity.id,
      data.Entity.name,
      data.Entity.serial_number,
      data.Entity.mac,
      data.Entity.ip,
      data.Entity.port,
      data.Entity.fw,
      data.Entity.type,
      data.Entity.status,
      data.Entity.synced_at,
      data.Entity.location_id
      );
  }

  public async Task<DeviceDto> UpdateIpAsync(string Mac, string Ip)
  {
    var entity = await context.Devices.Where(d => d.mac.Equals(Mac)).FirstOrDefaultAsync();
    if (entity == null)
      throw new Exception(DbExceptionMessage.RecordNotFound);

    entity.UpdateIp(Ip);

    var data = context.Devices.Update(entity);

    var save = await context.SaveChangesAsync();

    if (data == null || save <= 0)
      throw new Exception(DbExceptionMessage.SaveRecordUnsuccessful);

    return new DeviceDto(
      data.Entity.id,
      data.Entity.name,
      data.Entity.serial_number,
      data.Entity.mac,
      data.Entity.ip,
      data.Entity.port,
      data.Entity.fw,
      data.Entity.type,
      data.Entity.status,
      data.Entity.synced_at,
      data.Entity.location_id
      );
  }

      public async Task<DeviceDto> UpdatePortAsync(string Mac, int Port)
      {
           var entity = await context.Devices.Where(d => d.mac.Equals(Mac)).FirstOrDefaultAsync();
    if (entity == null)
      throw new Exception(DbExceptionMessage.RecordNotFound);

    entity.UpdatePort(Port);

    var data = context.Devices.Update(entity);

    var save = await context.SaveChangesAsync();

    if (data == null || save <= 0)
      throw new Exception(DbExceptionMessage.SaveRecordUnsuccessful);

    return new DeviceDto(
      data.Entity.id,
      data.Entity.name,
      data.Entity.serial_number,
      data.Entity.mac,
      data.Entity.ip,
      data.Entity.port,
      data.Entity.fw,
      data.Entity.type,
      data.Entity.status,
      data.Entity.synced_at,
      data.Entity.location_id
      );
      }
}
