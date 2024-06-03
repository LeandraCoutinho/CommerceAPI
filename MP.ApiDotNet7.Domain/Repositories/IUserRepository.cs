using MP.ApiDotNet7.Domain.Entities;

namespace MP.ApiDotNet7.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAndPasswordAsync(string email, string password);
}