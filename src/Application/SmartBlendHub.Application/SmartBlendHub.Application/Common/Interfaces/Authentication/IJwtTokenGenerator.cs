using SmartBlendHub.Domain.Entities;

namespace SmartBlendHub.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
