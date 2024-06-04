using CommerceAPI.Domain.Entities;

namespace CommerceAPI.Domain.Authentication;

public interface ITokenGenerator
{
    dynamic Generator(User user);
}