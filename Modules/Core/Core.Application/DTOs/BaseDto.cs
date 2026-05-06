using System;
using System.Net;

namespace Core.Application.DTOs;

public record BaseDto(HttpStatusCode Code, string Message, DateTime Timestamp);
