using System;

namespace Core.Application.Exceptions;

public class NotFoundException : Exception
{
  public NotFoundException() { }
  public NotFoundException(string Message) : base(Message) { }
  public NotFoundException(string Message, Exception InnerException) : base(Message, InnerException) { }
}
