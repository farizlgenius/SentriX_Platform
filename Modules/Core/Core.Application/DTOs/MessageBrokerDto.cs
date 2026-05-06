using System;

namespace Core.Application.DTOs;

public sealed record MessageBrokerDto(string Key,object Data);
