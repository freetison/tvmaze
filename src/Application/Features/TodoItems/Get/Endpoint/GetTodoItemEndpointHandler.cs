using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TvMaze.Application.Features.TodoItems.Get.EventHandlers;

namespace TvMaze.Application.Features.TodoItems.Get.Endpoint
{
    /// <summary>
    /// Defines the <see cref="GetTodoItemEndpointHandler" />.
    /// </summary>
    public class GetTodoItemEndpointHandler
    {
        /// <summary>
        /// The Handler.
        /// </summary>
        /// <param name="mediator">The mediator<see cref="IMediator"/>.</param>
        /// <param name="listId">The listId<see cref="int"/>.</param>
        /// <param name="pageNumber">The pageNumber<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{IResult}"/>.</returns>
        public static async Task<IResult> Handler([FromServices] IMediator mediator, [FromQuery] int listId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var request = new GetTodoItemsWithPaginationQuery(listId, pageNumber, pageSize);
            var todoItem = await mediator.Send(request);

            return Results.Ok(todoItem);
        }
    }
}
