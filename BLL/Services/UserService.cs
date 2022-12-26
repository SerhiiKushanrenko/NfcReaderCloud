using BLL.Services.Interfaces;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(User user)
        {
            await _userRepository.CreateAsync(user);
        }

        public async Task<int> GetAllUsers()
        {
            var result = _userRepository.GetAll().Count();
            return result;
        }
    }
}
