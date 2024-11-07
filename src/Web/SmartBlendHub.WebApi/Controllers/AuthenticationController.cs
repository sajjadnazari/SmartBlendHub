
using Microsoft.AspNetCore.Mvc;
using SmartBlendHub.Application.Services.Authentication;

namespace SmartBlendHub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("register")]
        public IActionResult Register(string id)
        {
            return new JsonResult(_authenticationService.Register("sdsd", "sdsd"));
        }

        [HttpPost("login")]
        public IActionResult Login(string id)
        {
            return Ok();
        }

    }
}
