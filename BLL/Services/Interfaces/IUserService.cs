using DAL.Models;

namespace BLL.Services.Interfaces
{
    public interface IUserService
    {
        public Task CreateUser(User user);
    }
}
