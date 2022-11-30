using BLL.DTOs;
using BLL.Hubs;
using BLL.Hubs.Interfaces;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace BLL.Services
{
    public class CheckService : ICheckService
    {
        private readonly Dictionary<Guid, string> _guidDictionary;
        private readonly IHubContext<CheckHub, ICheckHub> _hub;

        public CheckService(Dictionary<Guid, string> guidDictionary, IHubContext<CheckHub, ICheckHub> hub)
        {
            _guidDictionary = guidDictionary;
            _hub = hub;
        }
        public void Check(UserDTO userDto)
        {
            Task.Delay(1000).Wait();
            if (_guidDictionary.Keys.Contains(userDto.Id))
            {
                _hub.Clients.Client(_guidDictionary.FirstOrDefault(e => e.Key == userDto.Id).Value).CheckHubAsync(true);
            }

            _hub.Clients.Client(_guidDictionary.FirstOrDefault(e => e.Key == userDto.Id).Value).CheckHubAsync(false);

        }
    }
}
