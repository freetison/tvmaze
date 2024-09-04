namespace TvMaze.Application.Features
{
    using Microsoft.AspNetCore.Routing;

    /// <summary>
    /// Represents a feature in the application that can register services and map endpoints.
    /// </summary>
    public interface IFeature
    {
        /// <summary>
        /// Maps the endpoints related to this feature into the application's endpoint routing system.
        /// </summary>
        /// <param name="endpoints">The <see cref="IEndpointRouteBuilder"/> where endpoints are mapped.</param>
        /// <returns>The modified <see cref="IEndpointRouteBuilder"/>.</returns>
        IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
    }
}

