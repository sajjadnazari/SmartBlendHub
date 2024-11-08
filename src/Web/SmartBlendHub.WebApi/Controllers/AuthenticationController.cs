
using Microsoft.AspNetCore.Mvc;
using SmartBlendHub.Application.Common.Interfaces.Authentication;
using SmartBlendHub.Application.Services.Authentication;

namespace SmartBlendHub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public AuthenticationController(IAuthenticationService authenticationService, IJwtTokenGenerator jwtTokenGenerator)
        {
            _authenticationService = authenticationService;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        [HttpPost("register")]
        public IActionResult Register(string firstName, string lastName, string email, string password)
        {

            return new JsonResult(_authenticationService.Register(firstName, lastName, email, password));
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            return new JsonResult(_authenticationService.Login(email, password));
        }

    }
}
