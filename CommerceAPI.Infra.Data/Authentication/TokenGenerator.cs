using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using CommerceAPI.Domain.Authentication;
using CommerceAPI.Domain.Entities;

namespace CommerceAPI.Infra.Data.Authentication;

public class TokenGenerator : ITokenGenerator
{
    public dynamic Generator(User user)
    {
        var permission = string.Join(",", user.UserPermissions.Select(x => x.Permission?.PermissionName));
        var claims = new List<Claim>
        {
            new Claim("Email", user.Email),
            new Claim("ID", user.Id.ToString()),
            new Claim("Permissions", permission)
        };

        var expires = DateTime.Now.AddDays(1);
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("projetoDotNetCore6supersecurekey"));
        var tokenData = new JwtSecurityToken(
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
            expires: expires,
            claims: claims
        );

        var token = new JwtSecurityTokenHandler().WriteToken(tokenData);
        return new
        {
            acces_token = token,
            expirations = expires
        };
    }
}