using System;

namespace Identity.Contract.DTOs;

public sealed record LoginDto(string Username, string Password);
