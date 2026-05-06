using System;

namespace Identity.Contract.DTOs;

public sealed record DepartmentDto(int Id, string Name, string Description, int CompanyId, string CompanyName);
