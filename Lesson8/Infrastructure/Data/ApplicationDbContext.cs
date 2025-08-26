using Microsoft.EntityFrameworkCore;
using Lesson8.Infrastructure.Data.Entities;

namespace Lesson8.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }
        public DbSet<ProductEntity> ProductsEntity { get; set; }
        public DbSet<CategoryEntity> CategoriesEntity { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CategoryEntity>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<ProductEntity>()
                .HasOne(p => p.CategoryEntity)
                .WithMany(c => c.ProductsEntity)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(p=>p.CategoryId);
        }
    }
}
