using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Surzor.Identity.Models;
using System;
using System.Linq;

namespace Surzor.Identity.Seed
{
    public static class AddDefaultUser
    {
        public static void SeedAdminUser(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            using var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            if (!roleManager.Roles.Any(p => p.Name.Equals("Admin")))
                roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            if (!roleManager.Roles.Any(p => p.Name.Equals("User")))
                roleManager.CreateAsync(new IdentityRole("User")).GetAwaiter().GetResult();
            if (!userManager.Users.Any(p => p.UserName.Equals("admin")))
            {
                var user = new ApplicationUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "admin",
                    LastModifyDateTime = DateTime.Now,
                    CreateDateTime = DateTime.Now,
                    Email = "example@site.com",
                    EmailConfirmed = true,
                    FirstName = "Site",
                    LastName = "Admin"
                };
                var resultUser = userManager.CreateAsync(user, "Admin2021!").GetAwaiter().GetResult();
                var resultAddToRole = userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
            }
        }
    }
}
