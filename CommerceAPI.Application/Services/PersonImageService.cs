using CommerceAPI.Application.DTOs;
using CommerceAPI.Application.DTOs.Validations;
using CommerceAPI.Application.Services.Interfaces;
using CommerceAPI.Domain.Entities;
using CommerceAPI.Domain.Integrations;
using CommerceAPI.Domain.Repositories;

namespace CommerceAPI.Application.Services;

public class PersonImageService : IPersonImageService
{
    private readonly IPersonImageRepository _personImageRepository;
    private readonly IPersonRepository _personRepository;
    private readonly ISavePersonImage _savePersonImage;

    public PersonImageService(IPersonImageRepository personImageRepository, IPersonRepository personRepository, ISavePersonImage savePersonImage)
    {
        _personImageRepository = personImageRepository;
        _personRepository = personRepository;
        _savePersonImage = savePersonImage;
    }

    public async Task<ResultService> CreateImageBase64Async(PersonImageDTO personImageDto)
    {
        if (personImageDto == null)
            return ResultService.Fail("Objeto deve ser informado!");

        var validations = new PersonImageDTOValidation().Validate(personImageDto);
        if (!validations.IsValid)
            return ResultService.RequestError("Problemas de validasção", validations);

        var person = await _personRepository.GetByIdAsync(personImageDto.PersonId);
        if (person == null)
            return ResultService.Fail("Id pessoa não encontrado");

        var personImage = new PersonImage(person.Id, null, personImageDto.Image);
        await _personImageRepository.CreateAsync(personImage);
        return ResultService.Ok("Imagem em base64 salva!");
    }

    public async Task<ResultService> CreateImageAsync(PersonImageDTO personImageDto)
    {
        if (personImageDto == null)
            return ResultService.Fail("Onjeto deve ser irfotmado");

        var validations = new PersonImageDTOValidation().Validate(personImageDto);
        if (!validations.IsValid)
            return ResultService.RequestError("Proclemas de validação", validations);

        var person = await _personRepository.GetByIdAsync(personImageDto.PersonId);
        if (person == null)
            return ResultService.Fail("Pessoa não encontrada");

        var pathImage = _savePersonImage.Save(personImageDto.Image);
        var personImage = new PersonImage(person.Id, pathImage, null);
        await _personImageRepository.CreateAsync(personImage);
        return ResultService.Ok("Imagem salva!");
    }
}