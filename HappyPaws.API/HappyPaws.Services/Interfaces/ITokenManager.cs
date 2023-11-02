using HappyPaws.Core.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace HappyPaws.Application.Interfaces
{
    public interface ITokenManager
    {
        string CreateAccessTokenAsync(User user);
        JwtSecurityToken? DecodeAccessTokenAsync(string token);
    }
}
