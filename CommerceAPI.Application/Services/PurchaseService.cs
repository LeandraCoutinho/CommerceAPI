using AutoMapper;
using CommerceAPI.Application.DTOs.Validations;
using CommerceAPI.Application.Services.Interfaces;
using CommerceAPI.Domain.Entities;
using CommerceAPI.Domain.Repositories;

namespace CommerceAPI.Application.Services;

public class PurchaseService : IPurchaseService
{
    private readonly IProductRepository _productRepository;
    private readonly IPersonRepository _personRepository;
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unityOfWork;

    public PurchaseService(IProductRepository productRepository, IPersonRepository personRepository, IPurchaseRepository purchaseRepository, IMapper mapper, IUnitOfWork unityOfWork)
    {
        _productRepository = productRepository;
        _personRepository = personRepository;
        _purchaseRepository = purchaseRepository;
        _mapper = mapper;
        _unityOfWork = unityOfWork;
    }

    public async Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDto)
    {
        if (purchaseDto == null)
            return ResultService.Fail<PurchaseDTO>("Objeto deve ser informado!");

        var validate = new PurchaseDTOValidator().Validate(purchaseDto);
        if (!validate.IsValid)
            return ResultService.RequestError<PurchaseDTO>("Problemas de validação", validate);

        try
        {
            await _unityOfWork.BeginTransaction();
            var productId = await _productRepository.GetByIdCodErpAsync(purchaseDto.CodErp);
            if (productId == 0)
            {
                var product = new Product(purchaseDto.ProductName, purchaseDto.CodErp, purchaseDto.Price ?? 0);
                await _productRepository.CreateAsync(product);
                productId = product.Id;
            }

            var personId = await _personRepository.GetByIdDocumentAsync(purchaseDto.Document);
            var purchase = new Purchase(productId, personId);

            var data = await _purchaseRepository.CreateAsync(purchase);
            purchaseDto.Id = data.Id;
            await _unityOfWork.Commit();
            return ResultService.Ok<PurchaseDTO>(purchaseDto);
        }
        catch(Exception ex)
        {
            await _unityOfWork.Rollback();
            return ResultService.Fail<PurchaseDTO>($"{ex.Message}");
        }
        
    }

    public async Task<ResultService<PurchaseDetailDTO>> GetByIdAsync(int id)
    {
        var purchase = await _purchaseRepository.GetByIdAsync(id);
        if (purchase == null)
            return ResultService.Fail<PurchaseDetailDTO>("Compra não encontrada!");
        
        return ResultService.Ok(_mapper.Map<PurchaseDetailDTO>(purchase));
    }

    public async Task<ResultService<ICollection<PurchaseDetailDTO>>> GetAsync()
    {
        var purchases = await _purchaseRepository.GetAllAsync();
        return ResultService.Ok(_mapper.Map<ICollection<PurchaseDetailDTO>>(purchases));
    }

    public async Task<ResultService<PurchaseDTO>> UpdateAsync(PurchaseDTO purchaseDto)
    {
        if (purchaseDto == null)
            return ResultService.Fail<PurchaseDTO>("Compra não encontrada!");

        var result = new PurchaseDTOValidator().Validate(purchaseDto);
        if (!result.IsValid)
            return ResultService.RequestError<PurchaseDTO>("Problemas de validação", result);

        var purchase = await _purchaseRepository.GetByIdAsync(purchaseDto.Id);
        if (purchase == null)
            return ResultService.Fail<PurchaseDTO>("Compra não encontrada!");

        var productId = await _productRepository.GetByIdCodErpAsync(purchaseDto.CodErp); // busca o id do produto
        var personId = await _personRepository.GetByIdDocumentAsync(purchaseDto.Document); // busca o id do pessoa
        purchase.Edit(purchase.Id, productId, personId); // edita
        await _purchaseRepository.EditAsync(purchase); // caso não seja encontrado, cai em uma excessão (que está sendo tratada no controller)
        return ResultService.Ok(purchaseDto);
    }

    public async Task<ResultService> RemoveAsync(int id)
    {
        var purchase = await _purchaseRepository.GetByIdAsync(id);
        if (purchase == null)
            return ResultService.Fail<PurchaseDTO>("Compra não encontrada!");

        await _purchaseRepository.DeleteAsync(purchase);
        return ResultService.Ok($"Compra:{id} deletada");
    }
}