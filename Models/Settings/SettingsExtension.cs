namespace Clinic.Models.Settings
{
    public static class SettingsExtension
    {
        public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<Settings>()
                .Bind(configuration.GetSection(Settings.SectionName))
                .ValidateOnStart()
                .ValidateDataAnnotations();

            return services;
        }
    }
}
