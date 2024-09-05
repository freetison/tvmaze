namespace TvMaze.Application.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;
    using StackExchange.Redis;
    using TvMaze.Application.Common.Models.Settings;
    using TvMaze.HttpServiceProvider.DependencyInjection;
    using TvMaze.RabbitMqProvider.DependencyInjection;

    /// <summary>
    /// Defines the <see cref="ConfigureInfrastructureServices" />.
    /// </summary>
    public static class ConfigureInfrastructureServices
    {
        /// <summary>
        /// The AddInfrastructure.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="apiSettings">The apiSettings<see cref="ApiSettings"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ApiSettings apiSettings)
        {
            services.AddSqlserver(apiSettings);

            services.AddSingleton<IConnectionMultiplexer>(sp =>
             {
                 return ConnectionMultiplexer.Connect(apiSettings.ConnectionStrings.Redis);
             });

            services.AddRabbitMqProvider(apiSettings.RabbitMq);
            services.AddHttpProviders(apiSettings.ExternalApi.BaseUrl);

            services.AddAppServices();

            return services;
        }
    }
}