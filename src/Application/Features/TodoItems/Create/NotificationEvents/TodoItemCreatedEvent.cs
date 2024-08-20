using MediatR;

using TvMaze.Application.Domain.Todos;

namespace TvMaze.Application.Features.TodoItems.Create.NotificationEvents
{
    /// <summary>
    /// Defines the <see cref="TodoItemCreatedEvent" />.
    /// </summary>
    internal sealed class TodoItemCreatedEvent(TodoItem item) : INotification
    {
        /// <summary>
        /// Gets the Item.
        /// </summary>
        public TodoItem Item { get; } = item;
    }
}
