using BLL.DTOs;
using BLL.Hubs;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace BLL.Services
{
    public class CheckDataService : ICheckDataService
    {
        private readonly Dictionary<Guid, string> _guidDictionary;
        private readonly IHubContext<CheckHub> _hub;

        public CheckDataService(Dictionary<Guid, string> guidDictionary, IHubContext<CheckHub> hub)
        {
            _guidDictionary = guidDictionary;
            _hub = hub;
        }
        public void Check(UserAuthDTO userDto)
        {
            if (_guidDictionary.Keys.Contains(userDto.Id))
            {
                _hub.Clients.Client(_guidDictionary.FirstOrDefault(e => e.Key == userDto.Id).Value).SendAsync("Notify", true);
                return;
            }
            _hub.Clients.Client(_guidDictionary.FirstOrDefault(e => e.Key == userDto.Id).Value).SendAsync("Notify", false);
        }
    }
}
