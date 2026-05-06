using System;

namespace UINotifier.Contract.DTOs;

public sealed record UINotifierDto(string Key,object? Data = default!);