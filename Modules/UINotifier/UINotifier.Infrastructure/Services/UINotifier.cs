using System;
using Microsoft.AspNetCore.SignalR;
using UINotifier.Contract.Interfaces;
using UINotifier.Infrastructure.Hubs;

namespace Realtime.Api.Services;

public class UINotifier : IUINotifier
{
    private readonly IHubContext<UiHub> _hub;

    public UINotifier(IHubContext<UiHub> hub)
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