using Microsoft.AspNetCore.Mvc;
using MP.ApiDotNet7.Application.DTOs;
using MP.ApiDotNet7.Application.Services.Interfaces;

namespace MP.ApiDotNet7.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class PersonImageController : ControllerBase
{
    private readonly IPersonImageService _personImageService;

    public PersonImageController(IPersonImageService personImageService)
    {
        _personImageService = personImageService;
    }
    
    // salvar a imagem
    [HttpPost]
    public async Task<ActionResult> CreateImageBase64Async(PersonImageDTO personImageDto)
    {
        var result = await _personImageService.CreateImageBase64Async(personImageDto);
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpPost]
    [Route("pathimage")]
    public async Task<ActionResult> CreateImage(PersonImageDTO personImageDto)
    {
        var result = await _personImageService.CreateImageAsync(personImageDto);
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }
    
    
}