using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CommerceAPI.Application.DTOs;
using CommerceAPI.Application.Services.Interfaces;

namespace CommerceAPI.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UserController : ControllerBase
{
   private readonly IUserService _userService;

   public UserController(IUserService userService)
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