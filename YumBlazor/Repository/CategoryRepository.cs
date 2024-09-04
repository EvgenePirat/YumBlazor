using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();

            return category;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var categoryToDelete = await _db.Categories.FirstOrDefaultAsync(u => u.Id == id);

            if (categoryToDelete != null)
            {
                _db.Categories.Remove(categoryToDelete);
                return await _db.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category?> GetAsync(int id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(u => u.Id == id);

            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            var categoryToUpdate = await _db.Categories.FirstOrDefaultAsync(u => u.Id == category.Id);

            if(categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                _db.Categories.Update(categoryToUpdate);
                await _db.SaveChangesAsync();
            }

            return category;
        }
    }
}
