using Microsoft.EntityFrameworkCore;


namespace Lesson8.Model
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public ApplicationContext() 
        {
            Database.EnsureCreated();        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=goods.db");
        }
    }
}
