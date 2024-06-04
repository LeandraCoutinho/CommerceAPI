using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CommerceAPI.Application.DTOs.Validations;
using CommerceAPI.Application.Services;
using CommerceAPI.Application.Services.Interfaces;
using CommerceAPI.Domain.Validations;

namespace CommerceAPI.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]

public class PurchaseController : ControllerBase
{
    private readonly IPurchaseService _purchaseService;

    public PurchaseController(IPurchaseService purchaseService)
    {
        _purchaseService = purchaseService;
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync([FromBody] PurchaseDTO purchaseDto)
    {
        try
        {
            var result = await _purchaseService.CreateAsync(purchaseDto);
            if (result.IsSucsess)
                return Ok(result);

            return BadRequest(result);
        }
        catch(DomainValidationException ex)
        {
            var result = ResultService.Fail(ex.Message);
            return BadRequest(result);
        }
    }

    [HttpGet]
    public async Task<ActionResult> GetAsync()
    {
        var result = await _purchaseService.GetAsync();
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> GetByIdAsync(int id)
    {
        var result = await _purchaseService.GetByIdAsync(id);
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }
    
    [HttpPut]
    public async Task<ActionResult> EditAsync([FromBody] PurchaseDTO purchaseDto)
    {
        try
        {
            var result = await _purchaseService.UpdateAsync(purchaseDto);
            if (result.IsSucsess)
                return Ok(result);

            return BadRequest(result);
        }
        catch(DomainValidationException ex)
        {
            var result = ResultService.Fail(ex.Message);
            return BadRequest(result);
        }
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> RemoveAsync(int id)
    {
        var result = await _purchaseService.RemoveAsync(id);
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }
}