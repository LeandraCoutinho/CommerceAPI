using Microsoft.EntityFrameworkCore;
using CommerceAPI.Domain.Entities;
using CommerceAPI.Domain.Repositories;
using CommerceAPI.Infra.Data.Context;

namespace CommerceAPI.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _db;

    public UserRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string password)
    {
        return await _db.Users
            .Include(x => x.UserPermissions).ThenInclude(x => x.Permission)
            .FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
    }
}