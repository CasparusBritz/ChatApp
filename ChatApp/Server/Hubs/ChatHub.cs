using ChatApp.Shared;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message, string userName)
        {
            await Clients.All.SendAsync("SendMessage", userName, message);
        }

        public async Task SendUsername(string userName, string connectionID)
        {
            User.UserConnections.Add(connectionID, userName);
            await Clients.All.SendAsync("SendUsername", userName, connectionID);
        }

        public override async Task OnConnectedAsync()
        {
            
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            User.UserConnections.Remove(Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }


    }
}
