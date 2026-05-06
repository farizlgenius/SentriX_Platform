using System.Net;

namespace SentriX.BuildingBlock.DTOs;

public sealed record BaseDto(HttpStatusCode Code,string Message,DateTime Timestamp);