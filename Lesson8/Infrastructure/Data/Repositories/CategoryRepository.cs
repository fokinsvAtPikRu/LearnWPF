using Lesson8.Domain.Interfaces;
using Lesson8.Domain.Model;
using Lesson8.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lesson8.Infrastructure.Data.Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            var entities = await _context.CategoriesEntity.ToListAsync();
            return entities.Select(MapToDomain);
        }

        public async Task AddCategoryAsync(Category category)
        {
            var entity = MapToEntity(category);
            _context.CategoriesEntity.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var entity = await _context.CategoriesEntity.FindAsync(id);
            if (entity == null)
            {
                _context.CategoriesEntity.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            
        }
                

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var entity = await _context.CategoriesEntity.FindAsync(id);
            return entity == null ? null : MapToDomain(entity);
        }

        public async Task UpdateCategoryAsync(Product category)
        {
            var entity = await _context.CategoriesEntity.FindAsync(category.Id);
            if (entity == null)
            {
                entity.Name = category.Name;
                await _context.SaveChangesAsync();
            }
        }

        private Category MapToDomain(CategoryEntity entity) => new()
        {
            Id = entity.Id,
            Name = entity.Name           
        };
        private CategoryEntity MapToEntity(Category category) => new()
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}
