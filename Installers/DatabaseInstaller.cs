using Clinic.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Installers
{
    public static class DatabaseInstaller
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<Context>(
                    options => options.UseSqlServer(configuration.GetConnectionString("DataBase"))
                );

            return services;
        }
    }
}
