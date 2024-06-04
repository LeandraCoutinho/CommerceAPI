using CommerceAPI.Application.DTOs;
using CommerceAPI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CommerceAPI.Application.DTOs;
using CommerceAPI.Application.Services.Interfaces;

namespace CommerceAPI.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]

public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync([FromBody]ProductDTO productDto)
    {
        var result = await _productService.CreateAsync(productDto);
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpGet]
    public async Task<ActionResult> GetAsync()
    {
        var result = await _productService.GetAsync();
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> GetByIdAsync(int id)
    {
        var result = await _productService.GetByIdAsync(id);
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] ProductDTO productDto)
    {
        var result = await _productService.UpdateAsync(productDto);
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var result = await _productService.RemoveAsync(id);
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }
}