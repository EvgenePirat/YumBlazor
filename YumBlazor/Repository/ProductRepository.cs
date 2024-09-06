using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var productToDelete = await _db.Products.FirstOrDefaultAsync(u => u.Id == id);

            if (productToDelete != null)
            {
                _db.Products.Remove(productToDelete);
                return await _db.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product?> GetAsync(int id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(u => u.Id == id);

            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            var productToUpdate = await _db.Products.FirstOrDefaultAsync(u => u.Id == product.Id);

            if(productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;
                productToUpdate.ImageUrl = product.ImageUrl;
                productToUpdate.Description = product.Description;
                productToUpdate.CategoryId = product.CategoryId;
                _db.Products.Update(productToUpdate);
                await _db.SaveChangesAsync();
            }

            return product;
        }
    }
}
