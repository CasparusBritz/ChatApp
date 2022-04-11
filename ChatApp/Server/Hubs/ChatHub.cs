using ChatApp.Shared;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace ChatApp.Server.Hubs
{
    public class ChatHub : Hub
    {
        static ConcurrentDictionary<string, User> connectedUsers = new ConcurrentDictionary<string, User>();
        public async Task SendMessage(string message, string userName)
        {

            await Clients.All.SendAsync("SendMessage", userName, message);
        }

        public async Task SendUsername(string userName, string connectionID)
        {

            if (!connectedUsers.Keys.Any(x => x == Context.ConnectionId))
            {
                connectedUsers.TryAdd(Context.ConnectionId, new User { UserName = userName });
            }

            
            await Clients.All.SendAsync("RefreshUserNames", connectedUsers.Values.Select(x=>x.UserName));
        }

        public override async Task OnConnectedAsync()
        {

            await Clients.All.SendAsync("RefreshUserNames", connectedUsers.Values.Select(x => x.UserName));
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {

            connectedUsers.TryRemove(Context.ConnectionId, out _);

            await Clients.All.SendAsync("RefreshUserNames", connectedUsers.Values.Select(x => x.UserName));
            await base.OnDisconnectedAsync(e);
        }


    }
}
