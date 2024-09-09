namespace TvMaze.HttpWorker.DependencyInjection
{
    using System.Reflection;

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
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}