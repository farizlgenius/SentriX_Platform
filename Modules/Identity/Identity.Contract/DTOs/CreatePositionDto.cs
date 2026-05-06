using System;

namespace Identity.Contract.DTOs;

public sealed record CreatePositionDto(string Name,string Description,int DepartmentId);