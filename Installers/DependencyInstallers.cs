using Clinic.Interfaces;
using Clinic.Repositories;
using Clinic.Services;

namespace Clinic.Dependencies
{
    public static class DependencyInstallers
    {
        public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
        {
            services.AddScoped<TokenService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
