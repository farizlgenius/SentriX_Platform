using System.Net;

namespace Identity.Contract.DTOs;

public record BaseDto(HttpStatusCode Code, string Message, DateTime Timestamp);