using CommerceAPI.Domain.Entities;

namespace CommerceAPI.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAndPasswordAsync(string email, string password);
}