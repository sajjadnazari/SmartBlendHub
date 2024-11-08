using SmartBlendHub.Application.Common.Interfaces.Authentication;
using SmartBlendHub.Application.Common.Interfaces.Persistence;
using SmartBlendHub.Domain.Entities;

namespace SmartBlendHub.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public AuthenticationService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public AuthenticationResult Login(string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given email alreadt exists");
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User with given email alreadt exists");
            }

            var user = new User { Email = email, FirstName = firstName, LastName = lastName, Password = password };

            _userRepository.Add(user);

            return new AuthenticationResult(user, "");
        }
    }
}
