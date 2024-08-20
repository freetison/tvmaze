using MediatR;

using TvMaze.Application.Domain.Todos;
using TvMaze.Application.Infrastructure.Persistence;

namespace TvMaze.Application.Features.TodoItems.Create.EventHandlers
{
    /// <summary>
    /// Defines the <see cref="CreateTodoItemCommandHandler" />.
    /// </summary>
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, TodoItem>
    {
        private readonly ApplicationDbContext _context;

        public CreateTodoItemCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The Handle.
        /// </summary>
        /// <param name="request">The request<see cref="CreateTodoItemCommand"/>.</param>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<TodoItem> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoItem
            {
                ListId = request.ListId,
                Title = request.Title,
                Done = false,
            };

            entity.DomainEvents.Add(new TodoItemCreatedEvent(entity));

            _context.TodoItems.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }

    public record CreateTodoItemCommand(int ListId, string? Title) : IRequest<TodoItem>;
}
