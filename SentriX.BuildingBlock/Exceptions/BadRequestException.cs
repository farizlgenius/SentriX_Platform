using System;

namespace SentriX.BuildingBlock.Exceptions;

public sealed class BadRequestException : Exception
{
  public BadRequestException() { }
  public BadRequestException(string Message) : base(Message) { }
  public BadRequestException(string Message, Exception innerException) : base(Message, innerException) { }
}
