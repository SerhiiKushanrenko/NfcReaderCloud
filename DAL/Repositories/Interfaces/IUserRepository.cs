using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetAsync(string deviceId);
    }
}
