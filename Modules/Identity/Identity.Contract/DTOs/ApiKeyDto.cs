using System;

namespace Identity.Contract.DTOs;

public sealed record ApiKeyDto(string Key,string Owner,bool IsActive,DateTime ExpiredAt);

