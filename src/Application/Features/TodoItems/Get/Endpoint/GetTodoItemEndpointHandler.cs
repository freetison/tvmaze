using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TvMaze.Application.Common.Models;
using TvMaze.Application.Features.TodoItems.Get.EventHandlers;
using TvMaze.Application.Infrastructure.Services;

namespace TvMaze.Application.Features.TodoItems.Get.Endpoint
{
    /// <summary>
    /// Defines the <see cref="GetTodoItemEndpointHandler" />.
    /// </summary>
    public class GetTodoItemEndpointHandler
    {
        /// <summary>
        /// Defines the CacheKeyPrefix.
        /// </summary>
        private const string CacheKeyPrefix = "GetTodoItemsCacheKey";

        /// <summary>
        /// The Handler.
        /// </summary>
        /// <param name="mediator">The mediator<see cref="IMediator"/>.</param>
        /// <param name="cache">The cache<see cref="InMemoryCache"/>.</param>
        /// <param name="listId">The listId<see cref="int"/>.</param>
        /// <param name="pageNumber">The pageNumber<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{IResult}"/>.</returns>
        public static async Task<IResult> Handler([FromServices] IMediator mediator, [FromServices] InMemoryCache cache, [FromQuery] int listId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var cacheKey = $"{CacheKeyPrefix}_{pageNumber}_{pageSize}";
            var todoItems = cache.GetValue<PaginatedList<TodoItemBriefResponse>>(cacheKey);
            if (todoItems == null)
            {
                var request = new GetTodoItemsWithPaginationQuery(listId, pageNumber, pageSize);
                todoItems = await mediator.Send(request);

                // Guardamos los datos en caché
                cache.SetValue(cacheKey, todoItems, TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(2));
            }

            return Results.Ok(todoItems);
        }
    }
}
