using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CommerceAPI.Application.DTOs;
using CommerceAPI.Application.Services.Interfaces;

namespace CommerceAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]

public class PersonImageController : ControllerBase
{
    private readonly IPersonImageService _personImageService;

    public PersonImageController(IPersonImageService personImageService)
    {
        _personImageService = personImageService;
    }
    
    // salvar a imagem via base64
    [HttpPost]
    [Route("base64")]
    public async Task<ActionResult> CreateImageBase64Async(PersonImageDTO personImageDto)
    {
        var result = await _personImageService.CreateImageBase64Async(personImageDto);
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }
    
    // salvar a imagem via url
    [HttpPost]
    [Route("viaurl")]
    public async Task<ActionResult> CreateImage(PersonImageDTO personImageDto)
    {
        var result = await _personImageService.CreateImageAsync(personImageDto);
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }
    
    
}