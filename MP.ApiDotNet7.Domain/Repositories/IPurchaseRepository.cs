using MP.ApiDotNet7.Domain.Entities;

namespace MP.ApiDotNet7.Domain.Repositories;

public interface IPurchaseRepository
{
    Task<ICollection<Purchase>> GetByPersonIdAsync(int personId);
    Task<ICollection<Purchase>> GetByProductIdAsync(int productId);
    Task<Purchase> GetByIdAsync(int id);
    Task<ICollection<Purchase>> GetAllAsync();
    Task<Purchase> CreateAsync(Purchase purchase);
    Task EditAsync(Purchase purchase);
    Task DeleteAsync(Purchase purchase);
}