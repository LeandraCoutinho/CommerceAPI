using CommerceAPI.Application.DTOs;

namespace CommerceAPI.Application.Services.Interfaces;

public interface IUserService
{
    Task<ResultService<dynamic>> GenerateTokenAsync(UserDTO userDto);
}