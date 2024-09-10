namespace TvMaze.HttpWorker.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;
    using TvMaze.HttpServiceProvider.DependencyInjection;
    using TvMaze.HttpWorker.Commands;
    using TvMaze.HttpWorker.Workers;
    using TvMaze.RabbitMqProvider.DependencyInjection;
    using TvMaze.ShareCommon;
    using TvMaze.ShareCommon.Models.Settings;
    using TvMaze.ShareCommon.Models.TvMaze;

    using Tx.Core.GenericFactory;

    /// <summary>
    /// Defines the <see cref="ConfigureAppServices" />.
    /// </summary>
    public static class ConfigureAppServices
    {
        /// <summary>
        /// The ConfigureServices.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="appSettings">The appSettings<see cref="AppSettings"/>.</param>
        public static void ConfigureServices(IServiceCollection services, AppSettings appSettings)
        {
            services.AddLogging();
            services.AddAddMediatRService();
            services.AddScoped(sp =>
            {
                // push coomand is just a demo to handle more than one command
                var factory = new GenericFactory<string, IAppCommand<string, ShowInfo?>>();
                factory.Register(Constants.Commands[Constants.AppCommand.PULL], () => ActivatorUtilities.CreateInstance<PullCommand>(sp));
                factory.Register(Constants.Commands[Constants.AppCommand.PUSH], () => ActivatorUtilities.CreateInstance<PushCommand>(sp));

                return factory;
            });

            services.AddSingleton(appSettings);
            services.AddHttpProviders(appSettings.ExternalApi.BaseUrl);
            services.AddHostedService<HttpServiceWorker>();
            services.AddRabbitMqProvider(appSettings.RabbitMq);
        }
    }
}