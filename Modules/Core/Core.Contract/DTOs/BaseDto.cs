using System;
using System.Net;

namespace Core.Contract.DTOs;

public record BaseDto(HttpStatusCode Code, string Message, DateTime Timestamp);
