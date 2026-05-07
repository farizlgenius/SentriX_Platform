using System;
using Microsoft.AspNetCore.SignalR;
using Notifier.Infrastructure.Hubs;
using UINotifier.Contract.Interfaces;


namespace Notifier.Infrastructure.Services;

public sealed class NotifierService : INotifier
{
    private readonly IHubContext<NotifierHub> _hub;

    public NotifierService(IHubContext<NotifierHub> hub)
    {
        _hub = hub;
    }

    public async Task SendToTopic(string topic, object payload)
    {
        await _hub.Clients.Group(topic)
            .SendAsync(topic, payload);

        // await _hub.Clients.All.SendAsync(topic,payload);

    }

    public async Task SendToUser(string userId, object payload)
    {
        await _hub.Clients.Group($"user-{userId}")
            .SendAsync("private", payload);
    }
}