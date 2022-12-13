using DAL.EF;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class UserRepository : Repository<User>, IRepository<User>, IUserRepository
    {
        public UserRepository(NfcDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<User> GetAsync(string usbDeviceId)
        {
            var a = GetAll().ToList();
            return a.FirstOrDefault(user => user.UsbDeviceId == usbDeviceId);
        }
    }
}
