using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Sentrix.Contract.UiNotification.Interfaces;

namespace Realtime.Api.Hubs;

[Authorize]
public sealed class UiHub : Hub
{
      // User subscribes to a topic (group)
    public async Task Subscribe(string topic)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, topic);
         Console.WriteLine($"User {Context.User?.Identity?.Name} joined {topic}");
    }

    public async Task Unsubscribe(string topic)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, topic);
    }

    // Optional: auto join personal group
    public override async Task OnConnectedAsync()
    {
        var userId = Context.UserIdentifier;
        if (!string.IsNullOrEmpty(userId))
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"user-{userId}");
        }

        await base.OnConnectedAsync();
    }
}
