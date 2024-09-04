using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using TvMaze.Application.Features.TodoItems.Create.EventHandlers;

namespace TvMaze.Application.Features.TodoItems.Create.Endpoint
{
    /// <summary>
    /// Defines the <see cref="CreateTodoItemEndpoint" />.
    /// </summary>
    public class CreateTodoItemEndpoint : IFeature
    {
        private readonly IMediator _mediator;

        public CreateTodoItemEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// The MapEndpoints.
        /// </summary>
        /// <param name="endpoints">The endpoints<see cref="IEndpointRouteBuilder"/>.</param>
        /// <returns>The <see cref="IEndpointRouteBuilder"/>.</returns>
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("api/v1/run-job", async (CreateTodoItemCommand request) => await Handler(request));

            return endpoints;
        }

        /// <summary>
        /// The Handler.
        /// </summary>
        /// <param name="request">The request<see cref="CreateTodoItemCommand"/>.</param>
        /// <returns>The <see cref="Task{IResult}"/>.</returns>
        private async Task<IResult> Handler(CreateTodoItemCommand request)
        {
            var todoItem = await _mediator.Send(request);

            return Results.Ok(todoItem);
        }
    }
}
