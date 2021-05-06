using Microsoft.AspNetCore.Mvc;
using Surzor.Application.Contracts.Identity;
using Surzor.Application.Models.Authentication;
using System.Threading.Tasks;

namespace Surzor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateByMail(AuthenticationRequest request)
        {
            return Ok(await _authenticationService.AuthenticateByEmailAsync(request));
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateByUsername(AuthenticationRequest request)
        {
            return Ok(await _authenticationService.AuthenticateByUsernameAsync(request));
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            return Ok(await _authenticationService.RegisterAsync(request));
        }
    }
}
