namespace TvMaze.Api.DependencyInjection
{
    /// <summary>
    /// Defines the <see cref="ConfigureServices" />.
    /// </summary>
    public static class ConfigureServices
    {
        /// <summary>
        /// The ConfigureAppSettings.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="configuration">The configuration<see cref="IConfiguration"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddApiLogging()
                .AddCommonServices()
                .AddAppSettings(configuration)
                .AddSwaggerService(configuration)
                .AddSecurityServices()
                .AddHttpServices(configuration);

            return services;
        }
    }
}
