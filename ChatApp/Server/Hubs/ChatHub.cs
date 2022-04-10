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
            foreach (var userConn in ConnectedUsers.UserConnections)
            {
                if (userConn.Key == connectionID)
                {
                    userConn.Value.UserName = userName;
                }
            }

            await Clients.All.SendAsync("RefreshConnections",userName);
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();

            ConnectedUsers.UserConnections.Add(Context.ConnectionId, new());
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            await base.OnDisconnectedAsync(e);
            ConnectedUsers.UserConnections.Remove(Context.ConnectionId);
        }
      

    }
}
