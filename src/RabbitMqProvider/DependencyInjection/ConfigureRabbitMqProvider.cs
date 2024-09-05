namespace TvMaze.RabbitMqProvider.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;
    using RabbitMQ.Client;
    using TvMaze.RabbitMqProvider;
    using TvMaze.RabbitMqProvider.Models;

    /// <summary>
    /// Defines the <see cref="ConfigureRabbitMqProvider" />.
    /// </summary>
    public static class ConfigureRabbitMqProvider
    {
        /// <summary>
        /// The AddRabbitMqProvider.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="rabbitMqSettings">The rabbitMqSettings<see cref="RabbitMqSettings"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddRabbitMqProvider(this IServiceCollection services, RabbitMqSettings rabbitMqSettings)
        {
            var connectionFactory = new ConnectionFactory
            {
                UserName = rabbitMqSettings.RabbitMqUserName,
                Password = rabbitMqSettings.RabbitMqPassword,
                HostName = rabbitMqSettings.RabbitMqHostName,
                Port = rabbitMqSettings.RabbitMqPort,
                DispatchConsumersAsync = true,
                AutomaticRecoveryEnabled = true,
                ConsumerDispatchConcurrency = rabbitMqSettings.RabbitMqConcurrency,
            };

            services.AddSingleton(rabbitMqSettings);
            services.AddSingleton<IConnectionFactory>(_ => connectionFactory);
            services.AddSingleton(sp => ActivatorUtilities.CreateInstance<ModelFactory>(sp));
            services.AddSingleton(x => x.GetRequiredService<ModelFactory>().CreateChannel());
            services.AddSingleton<IRabbitMqClientProvider, RabbitMqClientProvider>();
            return services;
        }
    }
}