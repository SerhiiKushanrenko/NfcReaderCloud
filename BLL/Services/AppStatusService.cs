using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;

namespace BLL.Services
{
    public class AppStatusService : IAppStatusService
    {
        private readonly IUserRepository _userRepository;

        public AppStatusService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool GetAppStatus()
        {
            return _userRepository.CheckDbStatus();
        }
    }
}
