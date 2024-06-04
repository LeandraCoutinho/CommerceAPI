using MP.ApiDotNet7.Application.DTOs;

namespace MP.ApiDotNet7.Application.Services.Interfaces;

public interface IProductService
{
    Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDto);
    Task<ResultService<ICollection<ProductDTO>>> GetAsync();
    Task<ResultService<ProductDTO>> GetByIdAsync(int id);
    Task<ResultService> UpdateAsync(ProductDTO productDto);
    Task<ResultService> RemoveAsync(int id);
}