using AutoMapper;
using FluentValidation;
using MP.ApiDotNet6.Application.DTOs;
using MP.ApiDotNet6.Application.DTOs.Validations;
using MP.ApiDotNet6.Application.Services.Interfaces;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotNet6.Application.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public PersonService(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDto)
    {
        if (personDto == null)
            return ResultService.Fail<PersonDTO>("Objeto deve ser informado");

        var result = new PersonDTOValidator().Validate(personDto);
        if (!result.IsValid)
            return ResultService.RequestError<PersonDTO>("Problemas de validação", result);

        var person = _mapper.Map<Person>(personDto);
        var data = await _personRepository.CreateAsync(person);
        return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(data));
    }

    public async Task<ResultService<ICollection<PersonDTO>>> GetAsync()
    {
        var people = await _personRepository.GetPeopleAsync();
        return ResultService.Ok<ICollection<PersonDTO>>(_mapper.Map<ICollection<PersonDTO>>(people));
    }

    public async Task<ResultService<PersonDTO>> GetByIdAsync(int id)
    {
        var person = await _personRepository.GetByIdAsync(id);
        if (person == null)
            return ResultService.Fail<PersonDTO>("Pessoa não encontrada!");

        return ResultService.Ok(_mapper.Map<PersonDTO>(person));
    }

    public async Task<ResultService> UpdateAsync(PersonDTO personDto)
    {
        if (personDto == null)
            return ResultService.Fail("Objeto deve ser informado");

        var validation = new PersonDTOValidator().Validate(personDto);
        if (!validation.IsValid)
            return ResultService.RequestError("Problemas com a validação de campos", validation);

        var person = await _personRepository.GetByIdAsync(personDto.Id);
        if (person == null)
            return ResultService.Fail("Pessoa não encontrada");

        person = _mapper.Map<PersonDTO, Person>(personDto, person);
        await _personRepository.EditAsync(person);
        return ResultService.Ok("Pessoa editada!");
    }

    public async Task<ResultService> DeleteAsync(int id)
    {
        var person = await _personRepository.GetByIdAsync(id);
        if (person == null)
            return ResultService.Fail("Pessoa não encontrada");

        await _personRepository.DeleteAsync(person);
        return ResultService.Ok($"Pessoa do id:{id} foi deletada");
    }
}