using Lesson8.Domain.Interfaces;
using Lesson8.Domain.Model;
using Lesson8.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Windows;

namespace Lesson8.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddProductAsync(Domain.Model.Product product)
        {
            var entity = MapToEntity(product);
            _context.ProductsEntity.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
{
    var entity = await _context.ProductsEntity.FindAsync(id);
    if (entity != null)
    {
        _context.ProductsEntity.Remove(entity);
        await _context.SaveChangesAsync();
    }
}

public void Dispose()
{

}

public async Task<IEnumerable<Domain.Model.Product>> GetAllProductAsync()
{
    var entities = await _context.ProductsEntity
        .Include(p => p.CategoryEntity)
        .ToListAsync();
    return entities.Select(MapToDomain);
}

public async Task<Domain.Model.Product> GetProductByIdAsync(int id)
{
    var entity = await _context.ProductsEntity
         .Include(p => p.CategoryEntity)
         .FirstOrDefaultAsync(p => p.Id == id);

    return entity == null ? null : MapToDomain(entity);
}

public async Task UpdateProductAsync(Domain.Model.Product product)
{
    var entity = await _context.ProductsEntity.FindAsync(product.Id);
    if (entity != null)
    {
        entity.Name = product.Name;
        entity.Price = product.Price;
        entity.CategoryId = product.CategoryId;
        entity.Image = product.Image;
        await _context.SaveChangesAsync();
    }
}

private Domain.Model.Product MapToDomain(Entities.ProductEntity entity) => new()
{
    Id = entity.Id,
    Name = entity.Name,
    Price = entity.Price,
    CategoryId = entity.CategoryId,
    Category = new()
    {
        Id = entity.CategoryId,
        Name = entity.CategoryEntity.Name
    },
    Image = entity.Image
};

private Entities.ProductEntity MapToEntity(Domain.Model.Product product) => new()
{
    Id = product.Id,
    Name = product.Name,
    Price = product.Price,
    CategoryId = product.CategoryId,
    Image = product.Image
};
            
        
    }
}
