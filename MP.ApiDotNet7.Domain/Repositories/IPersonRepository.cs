using MP.ApiDotNet7.Domain.Entities;
using MP.ApiDotNet7.Domain.FiltersDb;

namespace MP.ApiDotNet7.Domain.Repositories;

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