using Microsoft.AspNetCore.SignalR;

namespace BLL.Hubs
{
    public class CheckHub : Hub
    {
        public async Task Connect(string userName)
        {
            await Clients.Caller.SendAsync("Chmo", $"user connect: {userName}");

        }
    }
}
