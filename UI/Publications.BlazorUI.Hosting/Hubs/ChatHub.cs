using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Publications.BlazorUI.Hosting.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string User, string Message) => await Clients.All.SendAsync("Message", User, Message);
    }
}
