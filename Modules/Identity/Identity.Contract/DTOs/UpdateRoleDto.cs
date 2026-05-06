using System;

namespace Identity.Contract.DTOs;

public sealed record UpdateRoleDto(int Id, string Name, List<PermissionDto> Permissions, int LocationId);