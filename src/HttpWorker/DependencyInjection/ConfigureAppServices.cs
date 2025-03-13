namespace TvMaze.HttpWorker.DependencyInjection
{
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using TvMaze.HttpServiceProvider.DependencyInjection;
    using TvMaze.HttpWorker.MesageHandlers;
    using TvMaze.HttpWorker.Workers;
    using TvMaze.RabbitMqProvider.DependencyInjection;
    using TvMaze.ShareCommon.Models.Message;
    using TvMaze.ShareCommon.Models.Settings;
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

            services.AddSingleton(sp =>
            {
                var factory = new GenericFactory<string, IRequest>();

                // factory.Register(Constants.Commands[Constants.AppCommand.PULL], () => new PullDataCommand("PULL"));
                //// Registrando comandos usando ActivatorUtilities para crear instancias dinámicamente
                // factory.RegisterCommand<string, string>("RUN", typeof(RunCommand));
                // factory.RegisterCommand<string, int>("PULL", typeof(PullCommand));
                // factory.RegisterCommand<string, bool>("PUSH", typeof(PushCommand));
                return factory;
            });

            // Register RunCommand and GetPersonQuery as keyed transient services
            // services.AddKeyedTransient<IRequest<,>>("PULL", (sp, _) => ActivatorUtilities.CreateInstance<PullDataCommandHandler>(sp));
            // services.AddKeyedTransient<IRequest<ShowInfo?>>("PUSH", (sp, _) => ActivatorUtilities.CreateInstance<PushCommand>(sp));
            services.AddTransient<IMessageHandler<string>, PushHandler>();

            // services.AddTransient<IMessageHandler<string>, GetHandler>();
            // services.AddTransient<IMessageHandler<string>, PushHandler>();
            services.AddAddMediatRService();

            // Register their handlers
            // services.AddTransient<IRequestHandler<PullCommand, List<ShowInfo?>>, PullCommandHandler>();
            // services.AddTransient<IRequestHandler<PushCommand, ShowInfo?>, PushCommandHandler>();
            // services.AddTransient(typeof(IGenericFactory<,>), typeof(GenericFactory<,>));

            // services.AddKeyedTransient<IAppCommand<string, object?>, PullCommand>(Constants.Commands[Constants.AppCommand.PULL]);
            // services.AddKeyedTransient<IAppCommand<string, object?>, PushCommand>(Constants.Commands[Constants.AppCommand.PUSH]);
            services.AddSingleton(appSettings);
            services.AddHttpProviders(appSettings.ExternalApi.BaseUrl);
            services.AddHostedService<HttpServiceWorker>();
            services.AddRabbitMqProvider(appSettings.RabbitMq);
        }
    }
}