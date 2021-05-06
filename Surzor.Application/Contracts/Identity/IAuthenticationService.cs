using Surzor.Application.Models.Authentication;
using System.Threading.Tasks;

namespace Surzor.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateByEmailAsync(AuthenticationRequest request);
        Task<AuthenticationResponse> AuthenticateByUsernameAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
