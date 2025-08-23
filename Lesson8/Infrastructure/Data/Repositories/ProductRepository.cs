using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson8.Domain.Interfaces;
using Lesson8.Domain.Model;
using Lesson8.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lesson8.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddProductAsync(Product product)
        {
            var entity = MapToEntity(product);
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllProdictAsync()
        {
            var entities = await _context.Products.ToListAsync();
            return entities.Select(MapToDomain);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
           var entity =await _context.Products.FindAsync(id);
           return entity == null ? null : MapToDomain(entity);
        }

        public Task UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        private Product MapToDomain(ProductEntity entity) => new()
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price,
            Image = entity.Image
        };

        private ProductEntity MapToEntity(Product product) => new()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Image = product.Image
        };
            
        
    }
}
