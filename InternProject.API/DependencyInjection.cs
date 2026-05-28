using InternProject.API.Controllers;
using InternProject.Infrastructure;
using InterProject.Application;
using Microsoft.AspNetCore.Mvc;

namespace InternProject.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddApplicationDI()
                .AddInfrastructureDI(configuration);

            return services;

        }
    }
}
