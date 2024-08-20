using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using TvMaze.Application.Features.TodoItems.Create.Endpoint;

namespace TvMaze.Application.Features.Errors
{
    /// <summary>
    /// Defines the <see cref="CreateTodoItemEndpoint" />.
    /// </summary>
    public class ErrorEndpoint : IFeature
    {
        /// <summary>
        /// The MapEndpoints.
        /// </summary>
        /// <param name="endpoints">The endpoints<see cref="IEndpointRouteBuilder"/>.</param>
        /// <returns>The <see cref="IEndpointRouteBuilder"/>.</returns>
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints
                .MapPost("api/v1/error", CreateTodoItemEndpointHandler.Handler)
                .ExcludeFromDescription();

            return endpoints;
        }
    }
}
