using CommerceAPI.Domain.Entities;

namespace CommerceAPI.Domain.Repositories;

public interface IPersonImageRepository
{
    Task<PersonImage?> GetByIdAsync(int id);
    Task<PersonImage> CreateAsync(PersonImage personImage);
    Task<ICollection<PersonImage>> GetByPersonIdAsync(int personId);
    Task EditAsync(PersonImage personImage);
}