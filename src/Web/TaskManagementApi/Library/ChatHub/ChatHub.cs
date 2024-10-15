using Microsoft.AspNetCore.SignalR;

namespace TaskManagementApi.Library.ChatHub
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
