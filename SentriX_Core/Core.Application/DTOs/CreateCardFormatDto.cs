using System;

namespace Core.Application.DTOs;

public sealed record CreateCardFormatDto(int Id, string Name, int LocationId);