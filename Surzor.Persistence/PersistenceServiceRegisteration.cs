using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Surzor.Application.Contracts.Persistence.Repositories;
using Surzor.Persistence.Repositories;

namespace Surzor.Persistence
{
    public static class PersistenceServiceRegisteration
    {

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<SurzorDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SurzorConnectionString"));
            });
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IResponderRepository, ResponderRepository>();
            return services;
        }

    }
}
