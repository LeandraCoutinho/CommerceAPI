using AutoMapper;
using CommerceAPI.Application.DTOs;
using CommerceAPI.Application.DTOs.Validations;
using CommerceAPI.Application.Services.Interfaces;
using FluentValidation;
using CommerceAPI.Domain.Entities;
using CommerceAPI.Domain.Repositories;

namespace CommerceAPI.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDto)
    {
        if (productDto == null)
            return ResultService.Fail<ProductDTO>("Objeto deve ser informado");

        var result = new ProductDTOValidator().Validate(productDto);
        if (!result.IsValid)
            return ResultService.RequestError<ProductDTO>("Problemas de validação", result);

        var product = _mapper.Map<Product>(productDto); // mapeia o local de salvar
        var data = await _productRepository.CreateAsync(product);
        return ResultService.Ok<ProductDTO>(_mapper.Map<ProductDTO>(data));
    }

    public async Task<ResultService<ICollection<ProductDTO>>> GetAsync()
    {
        var products = await _productRepository.GetProductsAsync();
        return ResultService.Ok<ICollection<ProductDTO>>(_mapper.Map<ICollection<ProductDTO>>(products));
    }

    public async Task<ResultService<ProductDTO>> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
            return ResultService.Fail<ProductDTO>("Produto não encontrado!");

        return ResultService.Ok(_mapper.Map<ProductDTO>(product));
    }

    public async Task<ResultService> UpdateAsync(ProductDTO productDto)
    {
        if (productDto == null) 
            return ResultService.Fail<ProductDTO>("Objeto deve ser informado!");
        
        var validation = new ProductDTOValidator().Validate(productDto); // verifica se os atributos obragtórios estão sendo informados
        if (!validation.IsValid)
            return ResultService.RequestError("Problemas de validação", validation);

        var product = await _productRepository.GetByIdAsync(productDto.Id); // procura pelo Id para atualizar
        if (product == null)
            return ResultService.Fail("Produto não encontrado!");

        product = _mapper.Map<ProductDTO, Product>(productDto, product);
        await _productRepository.EditAsync(product);
        return ResultService.Ok("Produto editado!");
    }

    public async Task<ResultService> RemoveAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
            return ResultService.Fail<ProductDTO>("Produto não encontrado!");

        await _productRepository.DeleteAsync(product);
        return ResultService.Ok($"Produto do id:{id} foi deletado!");
    }
}