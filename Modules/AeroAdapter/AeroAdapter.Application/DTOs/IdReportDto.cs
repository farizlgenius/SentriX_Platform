using System;

namespace AeroAdapter.Application.DTOs;

public sealed record IdReportDto(
      int Id,
      string SerialNumber,
      string Mac,
      string Fw
);
