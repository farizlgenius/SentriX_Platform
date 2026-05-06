using System;

namespace Core.Contract.DTOs;

public sealed record MessageBrokerDto(string Key,object Data);
