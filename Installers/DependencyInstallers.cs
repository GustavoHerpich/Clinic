using Clinic.Business;
using Clinic.Interfaces.Business;
using Clinic.Interfaces.Repository;
using Clinic.Repositories;
using Clinic.Services;

namespace Clinic.Dependencies
{
    public static class DependencyInstallers
    {
        public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
        {
            services.AddScoped<TokenService>();

            #region Repositories
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            #endregion

            #region Business
            services.AddScoped<IPatientBusiness, PatientBusiness>();
            services.AddScoped<IDoctorBusiness, DoctorBusiness>();
            #endregion

            return services;
        }
    }
}
