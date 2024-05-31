using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MP.ApiDotNet6.Application.DTOs;
using MP.ApiDotNet6.Application.Services.Interfaces;
using MP.ApiDotNet6.Domain.FiltersDb;

namespace MP.ApiDotNet6.Api.Controllers;

[Authorize]
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
    public async Task<ActionResult> PostAsync([FromBody] PersonDTO personDto)
    {
        var result = await _personService.CreateAsync(personDto);
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpGet]
    public async Task<ActionResult> GetAsync()
    {
        var result = await _personService.GetAsync();
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetByIdAsync(int id)
    {
        var result = await _personService.GetByIdAsync(id);
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }
    
    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] PersonDTO personDto)
    {
        var result = await _personService.UpdateAsync(personDto);
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var result = await _personService.DeleteAsync(id);
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }
    
    [HttpGet("paged")]
    public async Task<ActionResult> GetPagedAsync([FromQuery] PersonFilterDb personFilterDb)
    {
        var result = await _personService.GetPagedAsync(personFilterDb);
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }
}