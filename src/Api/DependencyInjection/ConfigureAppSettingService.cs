using TvMaze.Application.Common.Models.Settings;

namespace TvMaze.Api.DependencyInjection
{
    /// <summary>
    /// Defines the <see cref="ConfigureAppSettingService" />.
    /// </summary>
    public static class ConfigureAppSettingService
    {
        /// <summary>
        /// The ConfigureAppSettings.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="configuration">The configuration<see cref="IConfiguration"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiSettings>(configuration.GetSection(nameof(ApiSettings)));

            return services;
        }
    }
}
