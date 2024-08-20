using MediatR;

using TvMaze.Application.Common.Mappings;
using TvMaze.Application.Common.Models;
using TvMaze.Application.Domain.Todos;
using TvMaze.Application.Infrastructure.Persistence;

namespace TvMaze.Application.Features.TodoItems.Get.EventHandlers
{
    /// <summary>
    /// Defines the <see cref="GetTodoItemQueryHandler" />.
    /// </summary>
    public class GetTodoItemQueryHandler : IRequestHandler<GetTodoItemsWithPaginationQuery, PaginatedList<TodoItemBriefResponse>>
    {
        /// <summary>
        /// Defines the _context.
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTodoItemQueryHandler"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="ApplicationDbContext"/>.</param>
        public GetTodoItemQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The Handle.
        /// </summary>
        /// <param name="request">The request<see cref="GetTodoItemsWithPaginationQuery"/>.</param>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public Task<PaginatedList<TodoItemBriefResponse>> Handle(GetTodoItemsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return _context.TodoItems
                .Where(item => item.ListId == request.ListId)
                .OrderBy(item => item.Title)
                .Select(item => ToDto(item))
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }

        /// <summary>
        /// The ToDto.
        /// </summary>
        /// <param name="todoItem">The todoItem<see cref="TodoItem"/>.</param>
        /// <returns>The <see cref="TodoItemBriefResponse"/>.</returns>
        private static TodoItemBriefResponse ToDto(TodoItem todoItem) => new(todoItem.Id, todoItem.ListId, todoItem.Title, todoItem.Done);
    }

    public record TodoItemBriefResponse(int Id, int ListId, string? Title, bool Done);
    public record GetTodoItemsWithPaginationQuery(int ListId, int PageNumber = 1, int PageSize = 10) : IRequest<PaginatedList<TodoItemBriefResponse>>;
}
