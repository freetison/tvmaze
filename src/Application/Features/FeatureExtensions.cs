using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TvMaze.Application.Features
{
    /// <summary>
    /// Defines the <see cref="FeatureExtensions" />.
    /// </summary>
    public static class FeatureExtensions
    {
        /// <summary>
        /// Defines the RegisteredFeatures.
        /// </summary>
        private static readonly List<IFeature> RegisteredFeatures = new List<IFeature>();

        /// <summary>
        /// The RegisterFeatures.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection RegisterFeatures(this IServiceCollection services)
        {
            RegisteredFeatures.AddRange(DiscoverFeatures()
            .Select(feature =>
            {
                feature.RegisterFeature(services);
                return feature;
            }));

            return services;
        }

        /// <summary>
        /// The MapEndpoints.
        /// </summary>
        /// <param name="app">.</param>
        /// <returns>The <see cref="WebApplication"/>.</returns>
        public static WebApplication MapEndpoints(this WebApplication app)
        {
            RegisteredFeatures.ForEach(feature => feature.MapEndpoints(app));

            return app;
        }

        /// <summary>
        /// The DiscoverFeatures.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{IFeature}"/>.</returns>
        private static IEnumerable<IFeature> DiscoverFeatures()
        {
            return typeof(IFeature).Assembly
                .GetTypes()
                .Where(p => p.IsClass && p.IsAssignableTo(typeof(IFeature)))
                .Select(Activator.CreateInstance)
                .Cast<IFeature>();
        }
    }
}
