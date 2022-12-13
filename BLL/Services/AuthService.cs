using BLL.DTOs;
using BLL.Hubs;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly Dictionary<Guid, string> _guidDictionary;
        private readonly IHubContext<CheckHub> _hub;
        private readonly IUserRepository _userRepository;

        public AuthService(Dictionary<Guid, string> guidDictionary, IHubContext<CheckHub> hub, IUserRepository userRepository)
        {
            _guidDictionary = guidDictionary;
            _hub = hub;
            _userRepository = userRepository;
        }
        public async Task Check(UserAuthDTO userDto)
        {
            var user = await _userRepository.GetAsync(userDto.UsbDeviceId);
            if (user is not null)
            {
                if (_guidDictionary.Keys.Contains(userDto.DeviceId))
                {
                    await _hub.Clients.Client(_guidDictionary.FirstOrDefault(e => e.Key == userDto.DeviceId).Value).SendAsync("Notify", true, userDto.UsbDeviceId, userDto.Name);
                    return;
                }
                await _hub.Clients.Client(_guidDictionary.FirstOrDefault(e => e.Key == userDto.DeviceId).Value).SendAsync("Notify", false);
            }
            await _hub.Clients.Client(_guidDictionary.FirstOrDefault(e => e.Key == userDto.DeviceId).Value).SendAsync("Notify", false);
        }
    }
}
