using Microsoft.Extensions.DependencyInjection;
using Surzor.Application.Contracts.Infrastructure;
using Surzor.Infrastructure.FileExport;

namespace Surzor.Infrastructure
{
    public static class InfrastructureServiceRegisteration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<ICsvExporter, CsvExporter>();
            return services;
        }
    }
}
