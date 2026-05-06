using System;

namespace Realtime.Api.Interfaces;

public interface IUiNotifier
{
      Task SendToTopic(string topic, object payload);
    Task SendToUser(string userId, object payload);
}
