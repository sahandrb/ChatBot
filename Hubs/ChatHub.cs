using Microsoft.AspNetCore.SignalR;
using System.Security.Cryptography.X509Certificates;

namespace ChatBot.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string _Message , string _user)
        {
            var UserId = Context.User?.FindFirst("ID")?.Value;
            await Clients.Client(_user).SendAsync("ReciveMessage" , _Message , UserId );
        }
    }
}
