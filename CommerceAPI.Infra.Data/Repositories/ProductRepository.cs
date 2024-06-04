using Microsoft.EntityFrameworkCore;
using CommerceAPI.Domain.Entities;
using CommerceAPI.Domain.Repositories;
using CommerceAPI.Infra.Data.Context;

namespace CommerceAPI.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _db;

    public ProductRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<Product> GetByIdAsync(int id)
    {
        return await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ICollection<Product>> GetProductsAsync()
    {
        return await _db.Products.ToListAsync();
    }

    public async Task<Product> CreateAsync(Product product)
    {
        _db.Add(product);
        await _db.SaveChangesAsync();
        return product;
    }

    public async Task EditAsync(Product product)
    {
        _db.Update(product);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product product)
    {
        _db.Remove(product);
        await _db.SaveChangesAsync();
    }

    public async Task<int> GetByIdCodErpAsync(string codErp)
    {
        return (await _db.Products.FirstOrDefaultAsync(x => x.CodErp == codErp))?.Id ?? 0;
    }
}