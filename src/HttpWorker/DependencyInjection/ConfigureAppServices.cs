using HttpServiceProvider.DependencyInjection;

using TvMaze.HttpWorker.Workers;

namespace TvMaze.HttpWorker.DependencyInjection
{
    public static class ConfigureAppServices
    {
        public static void ConfigureServices(HostBuilderContext hostContext, IServiceCollection services)
        {
            services.AddLogging();
            services.AddAddMediatRService();
            services.AddRabbitMqConnection(hostContext);
            // services.AddHttpServices(hostContext);
            services.AddHttpProviders(hostContext);
            services.AddHostedService<HttpServiceWorker>();

        }

    }
}
