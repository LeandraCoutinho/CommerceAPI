using MP.ApiDotNet6.Application.DTOs;
using MP.ApiDotNet6.Application.Services.Interfaces;
using MP.ApiDotNet6.Domain.Authentication;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotNet6.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenGenerator _tokenGenerator;

    public UserService(IUserRepository userRepository, ITokenGenerator tokenGenerator)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ResultService<dynamic>> GenerateTokenAsync(UserDTO userDto)
    {
        if (userDto == null)
            return ResultService.Fail<dynamic>("Objeto deve ser informado");

        var validator = new UserDTOValidator().Validate(userDto);
        if (!validator.IsValid)
            return ResultService.RequestError<dynamic>("Problemas com a validação", validator);

        var user = await _userRepository.GetUserByEmailAndPasswordAsync(userDto.Email, userDto.Password);
        if (user == null)
            return ResultService.Fail<dynamic>("Usuário ou senha não encontrado!");
        
        return ResultService.Ok<dynamic>(_tokenGenerator.Generator(user));
    }
}