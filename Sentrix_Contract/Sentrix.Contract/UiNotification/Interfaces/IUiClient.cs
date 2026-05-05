using System;

namespace Sentrix.Contract.UiNotification.Interfaces;

public interface IUiClient
{
    Task ReceiveMessage(string topic, object payload);
}