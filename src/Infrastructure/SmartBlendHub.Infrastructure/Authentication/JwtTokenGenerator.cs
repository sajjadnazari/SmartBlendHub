using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartBlendHub.Application.Common.Interfaces.Authentication;
using SmartBlendHub.Application.Common.Interfaces.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartBlendHub.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JwtSetting _jwtSetting;
        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSetting> jwtSettingOption)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSetting = jwtSettingOption.Value;
        }
        public string GenerateToken(Guid userId, string firstName, string lastName)
        {
            var signingCreditional = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Secret)), SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userId.ToString()),
                 new Claim(JwtRegisteredClaimNames.GivenName,firstName),
                  new Claim(JwtRegisteredClaimNames.FamilyName,lastName),
                   new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSetting.Issuer,
                audience: _jwtSetting.Audience,
                expires:  _dateTimeProvider.UtcNow.AddMinutes( _jwtSetting.ExpiryMinutes),
                claims: claims,
                signingCredentials: signingCreditional
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
