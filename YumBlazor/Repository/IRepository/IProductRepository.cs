using YumBlazor.Data;

namespace YumBlazor.Repository.IRepository
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
        Task<Product?> GetAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
