using CommerceAPI.Domain.Entities;

namespace CommerceAPI.Domain.Repositories;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(int id);
    Task<ICollection<Product>> GetProductsAsync();
    Task<Product> CreateAsync(Product product);
    Task EditAsync(Product product);
    Task DeleteAsync(Product product);
    Task<int> GetByIdCodErpAsync(string codErp);

}