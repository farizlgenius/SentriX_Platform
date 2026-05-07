using System;

namespace AeroAdapter.Application.DTOs;

public sealed record IdReportDto(int ComponentId,string SerialNumber,string Mac,string Fw);

