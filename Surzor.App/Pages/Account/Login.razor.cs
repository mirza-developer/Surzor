using Microsoft.AspNetCore.Components;
using Surzor.App.Contracts;
using Surzor.App.ViewModels;
using System.Threading.Tasks;

namespace Surzor.App.Pages.Account
{
    public partial class Login
    {
        public string Message { get; set; }
        public LoginViewModel LoginViewModel { get; set; } = new();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }
        protected async Task HandleValidSubmit()
        {
            if (await AuthenticationService.Authenticate(LoginViewModel.Username, LoginViewModel.Password))
            {
                NavigationManager.NavigateTo("home");
            }
            Message = "کاربر یافت نشد";
        }
    }
}
