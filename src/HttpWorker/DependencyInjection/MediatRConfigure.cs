namespace TvMaze.HttpWorker.DependencyInjection
{
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Defines the <see cref="MediatRConfigure" />.
    /// </summary>
    public static class MediatRConfigure
    {
        /// <summary>
        /// The AddAddMediatRService.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public static object AddAddMediatRService(this IServiceCollection services)
        {
            // services.AddKeyedTransient<IRequest<List<ShowInfo?>>, PullCommand>("PULL");
            // services.AddKeyedTransient<IRequest<ShowInfo?>, PushCommand>("PUSH");
            services.AddMediatR(cfg =>
            {
                // cfg.RegisterServicesFromAssembly(typeof(PullCommand).Assembly);
                // cfg.RegisterServicesFromAssembly(typeof(PushCommand).Assembly);
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BusinessValidationPipeline<,>));
            return services;
        }
    }
}