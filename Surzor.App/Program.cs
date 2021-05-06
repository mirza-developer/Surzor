using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Surzor.App.Auth;
using Surzor.App.Contracts;
using Surzor.App.Services;
using Surzor.App.Services.Base;
using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace Surzor.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddSingleton(sp => new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44318/")
            });
            builder.Services.AddHttpClient<IClient, Client>(config =>
             {
                 config.BaseAddress = new Uri("https://localhost:44318/");
             });

            builder.Services.AddScoped<IResponderDataService, ResponderDataService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddBlazoredLocalStorage();
            await builder.Build().RunAsync();
        }
    }
}
