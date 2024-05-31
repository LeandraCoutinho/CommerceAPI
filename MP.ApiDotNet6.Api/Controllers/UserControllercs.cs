using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MP.ApiDotNet6.Application.DTOs;
using MP.ApiDotNet6.Application.Services.Interfaces;

namespace MP.ApiDotNet6.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UserControllercs : ControllerBase
{
   private readonly IUserService _userService;

   public UserControllercs(IUserService userService)
   {
      _userService = userService;
   }

   [HttpPost]
   [Route("token")]
   public async Task<ActionResult> PostAsync([FromForm] UserDTO userDto)
   {
      var result = await _userService.GenerateTokenAsync(userDto);
      if (result.IsSucsess)
         return Ok(result.Data);

      return BadRequest(result);
   }
}