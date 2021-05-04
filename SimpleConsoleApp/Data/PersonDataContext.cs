using Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public interface IPersonDataContext
    {
        DbSet<Domain.PersonEntity> PersonEntities { get; set; }
        int SaveChanges();
    }
    
    public class PersonDataContext : DbContext, IPersonDataContext
    {
        public DbSet<Domain.PersonEntity> PersonEntities { get; set; }
        
        public PersonDataContext()
        {
        }

        public PersonDataContext(DbContextOptions options) : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Person());
            base.OnModelCreating(modelBuilder);
        }
    }
}