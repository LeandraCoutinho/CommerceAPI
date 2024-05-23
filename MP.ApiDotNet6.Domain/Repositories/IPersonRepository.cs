using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Domain.Repositories;

public interface IPersonRepository
{
    // criar 5 métodos -- assinatura deles
    Task<Person> GetByIdAsync(int id);
    Task<ICollection<Person>> GetPeopleAsync();
    Task<Person> CreateAsync(Person person);
    Task EditAsync(Person person);
    Task DeleteAsync(Person person);
}