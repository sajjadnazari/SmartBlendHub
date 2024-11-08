using SmartBlendHub.Domain.Entities;

namespace SmartBlendHub.Application.Services.Authentication
{
    public record AuthenticationResult
    (
        User User,
        string Token
    );
}
