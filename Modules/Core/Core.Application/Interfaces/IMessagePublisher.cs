using System;

namespace Core.Application.Interfaces;

public interface IMessagePublisher
{
      Task PublishAsync<T>(string Exchange,string RoutingKey,T Message,CancellationToken ct = default);
}
