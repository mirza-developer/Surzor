using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Surzor.Identity.Models;

namespace Surzor.Identity
{
    public class SurzorIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public SurzorIdentityDbContext(DbContextOptions<SurzorIdentityDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
