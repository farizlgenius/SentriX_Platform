using System;

namespace Identity.Contract.DTOs;

public sealed record CreateDepartmentDto(string Name, string Description, int CompanyId);
