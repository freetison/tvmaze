namespace TvMaze.Api.DependencyInjection
{
    /// <summary>
    /// Defines the <see cref="ConfigureCommonServices" />.
    /// </summary>
    public static class ConfigureCommonServices
    {
        /// <summary>
        /// The AddCommonServices.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddCommonServices(this IServiceCollection services)
        {
            services
            .AddHttpContextAccessor()
            .AddEndpointsApiExplorer()
            .AddProblemDetails()
            .AddHealthChecks();

            return services;
        }
    }
}
