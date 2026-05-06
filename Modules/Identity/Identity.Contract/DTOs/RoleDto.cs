using System;

namespace Identity.Contract.DTOs;

public sealed record RoleDto(int Id, string Name, List<PermissionDto> Permissions, string LocationName);
