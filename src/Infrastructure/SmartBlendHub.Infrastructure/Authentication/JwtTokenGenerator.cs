using Microsoft.IdentityModel.Tokens;
using SmartBlendHub.Application.Common.Interfaces.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartBlendHub.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string GenerateToken(Guid userId, string firstName, string lastName)
        {
            var signingCreditional = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("T0pPEHxm1f2SR+PLMLhTg8Q7pQS2YaUzcwvr7CFtJ9g=")), SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userId.ToString()),
                 new Claim(JwtRegisteredClaimNames.GivenName,firstName),
                  new Claim(JwtRegisteredClaimNames.FamilyName,lastName),
                   new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };

            var securityToken = new JwtSecurityToken(
                issuer: "SmartBlendHub",
                expires: DateTime.Now.AddDays(1),
                claims: claims,
                signingCredentials: signingCreditional
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
