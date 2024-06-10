using Clinic.Models.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Clinic.Installers
{
    public static class AuthenticationInstaller
    {
        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceProvider = services.BuildServiceProvider();
            var settings = serviceProvider.GetRequiredService<Microsoft.Extensions.Options.IOptions<Settings>>().Value;

            byte[] key = Encoding.ASCII.GetBytes(settings.Secret);
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false
                    };
                });

            return services;
        }
    }
}
