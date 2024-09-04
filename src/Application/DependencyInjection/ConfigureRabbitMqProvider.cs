namespace TvMaze.Application.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;
    using RabbitMQ.Client;
    using TvMaze.Application.Common.Models.Settings;
    using TvMaze.RabbitMqProvider;

    public static class ConfigureRabbitMqProvider
    {
        public static IServiceCollection AddRabbitMqProvider(this IServiceCollection services, ApiSettings apiSettings)
        {
            RabbitMqSettings rabbitMqSettings = apiSettings.RabbitMq;
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