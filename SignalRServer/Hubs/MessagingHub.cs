using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRServer.Hubs
{
    public class MessagingHub : Hub
    {
        public async Task Message(string value) => await Clients.All.SendAsync("Message",value);
    }
}
