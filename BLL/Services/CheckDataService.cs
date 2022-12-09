using BLL.DTOs;
using BLL.Hubs;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace BLL.Services
{
    public class CheckDataService : ICheckDataService
    {
        private readonly Dictionary<Guid, string> _guidDictionary;
        private readonly IHubContext<CheckHub> _hub;
        private readonly IUserRepository _userRepository;

        public CheckDataService(Dictionary<Guid, string> guidDictionary, IHubContext<CheckHub> hub, IUserRepository userRepository)
        {
            _guidDictionary = guidDictionary;
            _hub = hub;
            _userRepository = userRepository;
        }
        public async Task Check(UserAuthDTO userDto)
        {
            var user = await _userRepository.GetAsync(userDto.DeviceId);
            if (user != null)
            {
                if (_guidDictionary.Keys.Contains(userDto.Id))
                {
                    _hub.Clients.Client(_guidDictionary.FirstOrDefault(e => e.Key == userDto.Id).Value).SendAsync("Notify", true, userDto.DeviceId);
                    return;
                }
                _hub.Clients.Client(_guidDictionary.FirstOrDefault(e => e.Key == userDto.Id).Value).SendAsync("Notify", false);
            }
        }
    }
}
