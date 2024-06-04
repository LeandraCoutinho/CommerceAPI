using CommerceAPI.Domain.Entities;
using CommerceAPI.Domain.FiltersDb;

namespace CommerceAPI.Domain.Repositories;

public interface IPersonRepository
{
    // criar 5 métodos -- assinatura deles
    Task<Person> GetByIdAsync(int id);
    Task<ICollection<Person>> GetPeopleAsync();
    Task<Person> CreateAsync(Person person);
    Task EditAsync(Person person);
    Task DeleteAsync(Person person);
    Task<int> GetByIdDocumentAsync(string document);
    Task<PagedBaseResponse<Person>> GetPagedAsync(PersonFilterDb request);
}