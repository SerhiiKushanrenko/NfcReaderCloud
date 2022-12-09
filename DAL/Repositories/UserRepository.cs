using DAL.EF;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : Repository<User>, IRepository<User>, IUserRepository
    {
        public UserRepository(NfcDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<User> GetAsync(string usbDeviceId)
        {
            return await GetAll().FirstOrDefaultAsync(user => user.UsbDeviceId == usbDeviceId);
        }
    }
}
