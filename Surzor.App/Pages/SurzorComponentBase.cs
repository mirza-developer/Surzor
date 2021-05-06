using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Surzor.App.Auth;
using Surzor.App.Contracts;
using System.Threading.Tasks;

namespace Surzor.App.Pages
{
    public class SurzorComponentBase : ComponentBase
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authenticationState = await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
            if (!authenticationState.User.Identity.IsAuthenticated)
            {
                NavigateToLogin();
            }
        }

        protected virtual void NavigateToLogin()
        {
            NavigationManager.NavigateTo("account/login");
        }

        protected virtual void NavigateToRegister()
        {
            NavigationManager.NavigateTo("register");
        }

        protected virtual async void Logout()
        {
            await AuthenticationService.Logout();
        }
    }
}
