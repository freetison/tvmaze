namespace TvMaze.Application.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;
    using StackExchange.Redis;
    using TvMaze.HttpServiceProvider.DependencyInjection;
    using TvMaze.RabbitMqProvider.DependencyInjection;
    using TvMaze.ShareCommon.Models.Settings;

    /// <summary>
    /// Defines the <see cref="ConfigureInfrastructureServices" />.
    /// </summary>
    public static class ConfigureInfrastructureServices
    {
        /// <summary>
        /// The AddInfrastructure.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="appSettings">The appSettings<see cref="AppSettings"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddSqlserver(appSettings);

            services.AddSingleton<IConnectionMultiplexer>(sp =>
             {
                 return ConnectionMultiplexer.Connect(appSettings.ConnectionStrings.Redis);
             });

            services.AddRabbitMqProvider(appSettings.RabbitMq);
            services.AddHttpProviders(appSettings.ExternalApi.BaseUrl);

            services.AddAppServices();

            return services;
        }
    }
}