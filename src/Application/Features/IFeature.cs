using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace TvMaze.Application.Features
{
    /// <summary>
    /// Represents a feature in the application that can register services and map endpoints.
    /// </summary>
    public interface IFeature
    {
        /// <summary>
        /// Registers the necessary services for this feature in the dependency injection container.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> where services are registered.</param>
        /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
        IServiceCollection RegisterFeature(IServiceCollection services);

        /// <summary>
        /// Maps the endpoints related to this feature into the application's endpoint routing system.
        /// </summary>
        /// <param name="endpoints">The <see cref="IEndpointRouteBuilder"/> where endpoints are mapped.</param>
        /// <returns>The modified <see cref="IEndpointRouteBuilder"/>.</returns>
        IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
    }
}
