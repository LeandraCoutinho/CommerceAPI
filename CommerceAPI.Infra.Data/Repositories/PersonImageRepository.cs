using Microsoft.EntityFrameworkCore;
using CommerceAPI.Domain.Entities;
using CommerceAPI.Domain.Repositories;
using CommerceAPI.Infra.Data.Context;

namespace CommerceAPI.Infra.Data.Repositories;

public class PersonImageRepository : IPersonImageRepository
{
    private readonly ApplicationDbContext _db;

    public PersonImageRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<PersonImage?> GetByIdAsync(int id)
    {
        return await _db.PersonImages.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<PersonImage> CreateAsync(PersonImage personImage)
    {
        _db.Add(personImage);
        await _db.SaveChangesAsync();
        return personImage;
    }

    public async Task<ICollection<PersonImage>> GetByPersonIdAsync(int personId)
    {
        return await _db.PersonImages.AsNoTracking().Where(x => x.PersonId == personId).ToListAsync();
    }

    public async Task EditAsync(PersonImage personImage)
    {
        _db.Update(personImage);
        await _db.SaveChangesAsync();
    }
}