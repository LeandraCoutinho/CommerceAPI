using Microsoft.AspNetCore.Mvc;
using MP.ApiDotNet6.Application.DTOs;
using MP.ApiDotNet6.Application.Services.Interfaces;

namespace MP.ApiDotNet6.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] PersonDTO personDto)
    {
        var result = await _personService.CreateAsync(personDto);
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }
}