using MP.ApiDotNet6.Application.DTOs;

namespace MP.ApiDotNet6.Application.Services.Interfaces;

public interface IPersonService
{
    Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDto);
    Task<ResultService<ICollection<PersonDTO>>> GetAsync();
    Task<ResultService<PersonDTO>> GetByIdAsync(int id);
    Task<ResultService> UpdateAsync(PersonDTO personDto);
    Task<ResultService> DeleteAsync(int id);

}