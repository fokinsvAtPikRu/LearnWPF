using Microsoft.EntityFrameworkCore;


namespace Lesson8.Model
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Product> Products => null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();        
        }        
    }
}
