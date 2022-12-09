using DAL.EF;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class Repository<EntType> : IRepository<EntType> where EntType : class
    {
        private readonly NfcDbContext _context;

        public Repository(NfcDbContext context)
        {
            _context = context;
        }
        public Task<int> CreateAsync(EntType entity)
        {
            _context.Add(entity);
            return _context.SaveChangesAsync();
        }

        public IQueryable<EntType> GetAll()
        {
            return _context.Set<EntType>().AsQueryable();
        }

        public bool CheckDbStatus()
        {
            return _context.Database.CanConnect();
        }
    }
}
