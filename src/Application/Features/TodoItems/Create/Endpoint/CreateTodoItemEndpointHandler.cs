using MediatR;

using Microsoft.AspNetCore.Http;

using TvMaze.Application.Features.TodoItems.Create.EventHandlers;

namespace TvMaze.Application.Features.TodoItems.Create.Endpoint
{
    /// <summary>
    /// Defines the <see cref="CreateTodoItemEndpointHandler" />.
    /// </summary>
    public class CreateTodoItemEndpointHandler
    {
        /// <summary>
        /// The Handler.
        /// </summary>
        /// <param name="mediator">The mediator<see cref="IMediator"/>.</param>
        /// <param name="request">The request<see cref="CreateTodoItemCommand"/>.</param>
        /// <returns>The <see cref="Task{IResult}"/>.</returns>
        public static async Task<IResult> Handler(IMediator mediator, CreateTodoItemCommand request)
        {
            var todoItem = await mediator.Send(request);

            // var @event = new TodoItemCreatedEvent(todoItem);
            // await mediator.Publish(@event);
            return Results.Ok(todoItem);
        }
    }
}
