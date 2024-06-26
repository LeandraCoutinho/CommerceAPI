using CommerceAPI.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CommerceAPI.Application.DTOs;
using CommerceAPI.Application.Services.Interfaces;
using CommerceAPI.Domain.Authentication;
using CommerceAPI.Domain.FiltersDb;

namespace CommerceAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]

public class PersonController : BaseController
{
    private readonly IPersonService _personService;
    private readonly ICurrentUser _currentUser;
    private List<string> _permissionNeeded = new List<string>(){"Admin"};
    private readonly List<string> _permissionUser;

    public PersonController(IPersonService personService, ICurrentUser currentUser)
    {
        _personService = personService;
        _currentUser = currentUser;
        _permissionUser = _currentUser?.Permissions?.Split(",")?.ToList() ?? new List<string>();
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] PersonDTO personDto)
    {
        _permissionNeeded.Add("CadastroPessoa");
        if (!ValidPermission(_permissionUser, _permissionNeeded))
            return Forbidden();
        
        var result = await _personService.CreateAsync(personDto);
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        _permissionNeeded.Add("BuscaPessoa");
        if (!ValidPermission(_permissionUser, _permissionNeeded))
            return Forbidden();
        
        var result = await _personService.GetAsync();
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        _permissionNeeded.Add("BuscaPessoa");
        if (!ValidPermission(_permissionUser, _permissionNeeded))
            return Forbidden();
        
        var result = await _personService.GetByIdAsync(id);
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] PersonDTO personDto)
    {
        _permissionNeeded.Add("EditaPessoa");
        if (!ValidPermission(_permissionUser, _permissionNeeded))
            return Forbidden();
        
        var result = await _personService.UpdateAsync(personDto);
        if (result.IsSucsess)
            return Ok(result);

        return BadRequest(result);
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        _permissionNeeded.Add("DeletaPessoa");
        if (!ValidPermission(_permissionUser, _permissionNeeded))
            return Forbidden();
        
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