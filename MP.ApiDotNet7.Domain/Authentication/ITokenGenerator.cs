using MP.ApiDotNet7.Domain.Entities;

namespace MP.ApiDotNet7.Domain.Authentication;

public interface ITokenGenerator
{
    dynamic Generator(User user);
}