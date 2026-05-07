using System;

namespace UINotifier.Contract.DTOs;

public sealed record NotifierDto(string Key,object? Data = default!);