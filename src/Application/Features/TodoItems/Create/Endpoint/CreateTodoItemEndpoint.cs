using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace TvMaze.Application.Features.TodoItems.Create.Endpoint
{
    /// <summary>
    /// Defines the <see cref="CreateTodoItemEndpoint" />.
    /// </summary>
    public class CreateTodoItemEndpoint : IFeature
    {
        /// <summary>
        /// The MapEndpoints.
        /// </summary>
        /// <param name="endpoints">The endpoints<see cref="IEndpointRouteBuilder"/>.</param>
        /// <returns>The <see cref="IEndpointRouteBuilder"/>.</returns>
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("api/v1/todo-items/create", CreateTodoItemEndpointHandler.Handler);

            return endpoints;
        }
    }
}
