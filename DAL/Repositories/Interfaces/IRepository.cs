namespace DAL.Repositories.Interfaces
{
    public interface IRepository<EntType>
    {
        IQueryable<EntType> GetAll();
        Task<int> CreateAsync(EntType entity);
        public bool CheckDbStatus();

    }
}
