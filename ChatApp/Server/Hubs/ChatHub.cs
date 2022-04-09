using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message, string userName)
        {
           await Clients.All.SendAsync("SendMessage", userName, message);
        }

    }
}
