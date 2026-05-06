using System;

namespace UINotifier.Contract.Interfaces;

public interface IUINotifier
{
      Task SendToTopic(string topic, object payload);
    Task SendToUser(string userId, object payload);
}
