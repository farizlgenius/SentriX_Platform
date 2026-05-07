using System;

namespace UINotifier.Contract.Interfaces;

public interface INotifier
{
    Task SendToTopic(string topic, object payload);
    Task SendToUser(string userId, object payload);
}
