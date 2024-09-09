namespace TvMaze.HttpWorker.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;
    using TvMaze.HttpWorker.Workers;
    using TvMaze.RabbitMqProvider.DependencyInjection;
    using TvMaze.ShareCommon.Models.Settings;

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
            services.AddSingleton<AppSettings>(appSettings);
            services.AddHostedService<HttpServiceWorker>();
            services.AddRabbitMqProvider(appSettings.RabbitMq);
        }
    }
}