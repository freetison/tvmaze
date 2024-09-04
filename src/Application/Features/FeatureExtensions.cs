namespace TvMaze.Application.Features
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

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
        /// The MapEndpoints.
        /// </summary>
        /// <param name="app">The app<see cref="WebApplication"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static WebApplication MapEndpoints(this WebApplication app)
        {
            RegisteredFeatures.AddRange(DiscoverFeatures(app.Services));
            RegisteredFeatures.ForEach(feature => feature.MapEndpoints(app));
            return app;
        }

        /// <summary>
        /// The DiscoverFeatures.
        /// </summary>
        /// <param name="serviceProvider">The serviceProvider<see cref="IServiceProvider"/>.</param>
        /// <returns>The <see cref="IEnumerable{IFeature}"/>.</returns>
        private static IEnumerable<IFeature> DiscoverFeatures(IServiceProvider serviceProvider)
        {
            {
                var featureTypes = typeof(IFeature).Assembly
                    .GetTypes()
                    .Where(t => t.IsClass && !t.IsAbstract && typeof(IFeature).IsAssignableFrom(t));

                foreach (var featureType in featureTypes)
                {
                    var feature = ActivatorUtilities.CreateInstance(serviceProvider, featureType) as IFeature;

                    if (feature != null)
                    {
                        yield return feature;
                    }
                }
            }
        }
    }
}
