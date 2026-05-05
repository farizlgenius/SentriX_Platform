using System;
using Microsoft.AspNetCore.SignalR;
using Realtime.Api.Hubs;
using Realtime.Api.Interfaces;
using Sentrix.Contract.UiNotification.Interfaces;

namespace Realtime.Api.Services;

public class UiNotifier : IUiNotifier
{
    private readonly IHubContext<UiHub, IUiClient> _hub;

    public UiNotifier(IHubContext<UiHub, IUiClient> hub)
    {
        _hub = hub;
    }

    public async Task SendToTopic(string topic, object payload)
    {
        await _hub.Clients.Group(topic)
            .ReceiveMessage(topic, payload);
    }

    public async Task SendToUser(string userId, object payload)
    {
        await _hub.Clients.Group($"user-{userId}")
            .ReceiveMessage("private", payload);
    }
}