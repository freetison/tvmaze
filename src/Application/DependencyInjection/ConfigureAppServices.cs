namespace TvMaze.Application.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;
    using TvMaze.Application.Common.Interfaces;
    using TvMaze.Application.Infrastructure.Services;

    /// <summary>
    /// Defines the <see cref="ConfigureAppServices" />.
    /// </summary>
    public static class ConfigureAppServices
    {
        /// <summary>
        /// The AddAppServices.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            return services;
        }
    }
}