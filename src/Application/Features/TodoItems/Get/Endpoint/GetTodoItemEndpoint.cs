using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace TvMaze.Application.Features.TodoItems.Get.Endpoint
{
    /// <summary>
    /// Defines the <see cref="GetTodoItemEndpoint" />.
    /// </summary>
    public class GetTodoItemEndpoint : IFeature
    {
        /// <summary>
        /// The MapEndpoints.
        /// </summary>
        /// <param name="endpoints">The endpoints<see cref="IEndpointRouteBuilder"/>.</param>
        /// <returns>The <see cref="IEndpointRouteBuilder"/>.</returns>
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("api/v1/todo-items", GetTodoItemEndpointHandler.Handler);

            return endpoints;
        }
    }
}
