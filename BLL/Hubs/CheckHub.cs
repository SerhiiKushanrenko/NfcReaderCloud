using BLL.Hubs.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace BLL.Hubs
{
    public class CheckHub : Hub<ICheckHub>
    {
        public CheckHub()
        {

        }
    }
}
