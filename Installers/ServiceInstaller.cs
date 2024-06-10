using Clinic.Dependencies;

namespace Clinic.Installers
{
    public static class ServiceInstaller
    {
        public static IServiceCollection InstallServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddProjectDependencies();
            services.AddSwagger();
            services.AddAuthenticationServices(configuration);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:8080", "https://localhost:8080")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .AllowCredentials());
            });
            services.AddDatabase(configuration);

            return services;
        }
    }
}
