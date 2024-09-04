namespace TvMaze.Api.DependencyInjection
{
    using TvMaze.Application.Common.Models.Settings;

    /// <summary>
    /// Defines the <see cref="ConfigureServices" />.
    /// </summary>
    public static class ConfigureServices
    {
        /// <summary>
        /// The ConfigureAppSettings.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="apiSettings">The apiSettings<see cref="ApiSettings"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddApiServices(this IServiceCollection services, ApiSettings apiSettings)
        {
            services
                .AddSingleton(apiSettings)
                .AddApiLogging()
                .AddCommonServices()
                .AddSwaggerService(apiSettings)
                .AddSecurityServices(apiSettings)
                .AddHttpServices(apiSettings);

            return services;
        }
    }
}