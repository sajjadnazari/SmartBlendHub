namespace SmartBlendHub.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Login(string firstName, string lastName, string email, string username, string password, string token);
        AuthenticationResult Register(string email, string password, string token);
    }
}
