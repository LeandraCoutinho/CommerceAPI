using MP.ApiDotNet7.Domain.Entities;

namespace MP.ApiDotNet7.Domain.Repositories;

public interface IPersonImageRepository
{
    Task<PersonImage?> GetByIdAsync(int id);
    Task<PersonImage> CreateAsync(PersonImage personImage);
    Task<ICollection<PersonImage>> GetByPersonIdAsync(int personId);
    Task EditAsync(PersonImage personImage);
}