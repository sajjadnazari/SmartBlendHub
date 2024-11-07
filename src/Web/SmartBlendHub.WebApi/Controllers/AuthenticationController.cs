
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
        public IActionResult Register(string firstName, string lastName)
        {
            Guid userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
            return new JsonResult(_authenticationService.Register("sdsd", "sdsd",token));
        }

        [HttpPost("login")]
        public IActionResult Login(string id)
        {
            return Ok();
        }

    }
}
