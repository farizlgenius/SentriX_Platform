using System;
namespace Identity.Contract.DTOs;

public record CompanyDto(int Id, string Name, string Description, string Address);
