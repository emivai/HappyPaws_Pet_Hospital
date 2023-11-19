using HappyPaws.Application.Interfaces;
using HappyPaws.Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HappyPaws.Application.Services
{
    public class TokenManager : ITokenManager
    {
        private readonly SymmetricSecurityKey _authSigningKey;
        private readonly string _issuer;
        private readonly string _audience;
        public TokenManager(IConfiguration configuration)
        {
            _authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"] ?? throw new Exception()));
            _issuer = configuration["JWT:ValidIssuer"] ?? throw new Exception();
            _audience = configuration["JWT:ValidAudience"] ?? throw new Exception();
        }

        public string CreateAccessToken(User user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Type.ToString()),
                new Claim("UserId", user.Id.ToString())
            };

            var accessSecurityToken = new JwtSecurityToken
            (
                issuer: _issuer,
                audience: _audience,
                expires: DateTime.UtcNow.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(_authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(accessSecurityToken);
        }

        public JwtSecurityToken? DecodeAccessToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            return handler.ReadJwtToken(accessToken);
        }
    }
}
