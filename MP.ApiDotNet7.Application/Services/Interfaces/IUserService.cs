using MP.ApiDotNet7.Application.DTOs;

namespace MP.ApiDotNet7.Application.Services.Interfaces;

public interface IUserService
{
    Task<ResultService<dynamic>> GenerateTokenAsync(UserDTO userDto);
}