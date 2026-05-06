using System;
using Microsoft.AspNetCore.SignalR;
using Realtime.Api.Hubs;
using Realtime.Api.Interfaces;
using Sentrix.Contract.UiNotification.Interfaces;

namespace Realtime.Api.Services;

public class UiNotifier : IUiNotifier
{
    private readonly IHubContext<UiHub> _hub;

    public UiNotifier(IHubContext<UiHub> hub)
    {
        _hub = hub;
    }

    public async Task SendToTopic(string topic, object payload)
    {
        // await _hub.Clients.Group(topic)
        //     .SendAsync(topic, payload);

        await _hub.Clients.All.SendAsync(topic,payload);

    }

    public async Task SendToUser(string userId, object payload)
    {
        await _hub.Clients.Group($"user-{userId}")
            .SendAsync("private", payload);
    }
}