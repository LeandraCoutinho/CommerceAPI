using CommerceAPI.Application.DTOs;
using CommerceAPI.Domain.FiltersDb;
using CommerceAPI.Domain.Repositories;

namespace CommerceAPI.Application.Services.Interfaces;

public interface IPersonService
{
    Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDto);
    Task<ResultService<ICollection<PersonDTO>>> GetAsync();
    Task<ResultService<PersonDTO>> GetByIdAsync(int id);
    Task<ResultService> UpdateAsync(PersonDTO personDto);
    Task<ResultService> DeleteAsync(int id);
    Task<ResultService<PagedBaseResponseDTO<PersonDTO>>> GetPagedAsync(PersonFilterDb personFilterDb);


}