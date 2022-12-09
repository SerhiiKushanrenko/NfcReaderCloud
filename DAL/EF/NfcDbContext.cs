using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class NfcDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public NfcDbContext()
        {
        }

        public NfcDbContext(DbContextOptions<NfcDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseNpgsql();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
