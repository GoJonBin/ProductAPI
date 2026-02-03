using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id, bool asNoTracking);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
    }
}
