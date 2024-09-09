namespace TvMaze.Api.DependencyInjection
{
    using TvMaze.ShareCommon.Models.Settings;

    /// <summary>
    /// Defines the <see cref="ConfigureServices" />.
    /// </summary>
    public static class ConfigureServices
    {
        /// <summary>
        /// The ConfigureAppSettings.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="appSettings">The appSettings<see cref="AppSettings"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddApiServices(this IServiceCollection services, AppSettings appSettings)
        {
            services
                .AddSingleton(appSettings)
                .AddApiLogging()
                .AddCommonServices()
                .AddSwaggerService(appSettings)
                .AddSecurityServices(appSettings)
                .AddHttpServices(appSettings);

            return services;
        }
    }
}