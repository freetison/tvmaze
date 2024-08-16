using System.Reflection;

using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

using TvMaze.Application.Common.Behaviours;
using TvMaze.Application.Features;

namespace TvMaze.Application.DependencyInjection
{
    /// <summary>
    /// Defines the <see cref="ConfigureApplicationServices" />.
    /// </summary>
    public static class ConfigureApplicationServices
    {
        /// <summary>
        /// The AddApplication.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

                options.AddOpenBehavior(typeof(AuthorizationBehaviour<,>));
                options.AddOpenBehavior(typeof(ValidationBehaviour<,>));
                options.AddOpenBehavior(typeof(PerformanceBehaviour<,>));
                options.AddOpenBehavior(typeof(UnhandledExceptionBehaviour<,>));
            });

            services.RegisterFeatures();

            return services;
        }
    }
}
