using HappyPaws.Core.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace HappyPaws.Application.Interfaces
{
    public interface ITokenManager
    {
        string CreateAccessToken(User user);
        JwtSecurityToken? DecodeAccessToken(string token);
    }
}
