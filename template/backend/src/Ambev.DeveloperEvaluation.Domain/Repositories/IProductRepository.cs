using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;
public interface IProductRepository
{
    Task<Product> GetProductByIdAsync(int id);
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);
    Task UpdateProductAsync(Product product);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}