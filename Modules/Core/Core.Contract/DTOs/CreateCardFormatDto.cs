using System;

namespace Core.Contract.DTOs;

public sealed record CreateCardFormatDto(int Id, string Name, int LocationId);