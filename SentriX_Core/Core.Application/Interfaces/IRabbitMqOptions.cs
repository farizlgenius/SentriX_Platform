using System;

namespace Core.Application.Interfaces;

public interface IRabbitMqOptions
{
  string Host { get; }
  string Username { get; }
  string Password { get; }
  int Port { get; }

}
