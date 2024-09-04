namespace TvMaze.Application.Domain.Todos
{
    using TvMaze.Application.Common;

    /// <summary>
    /// Defines the <see cref="TodoItemDeletedEvent" />.
    /// </summary>
    internal sealed class TodoItemDeletedEvent(TodoItem item) : DomainEvent
    {
        /// <summary>
        /// Gets the Item.
        /// </summary>
        public TodoItem Item { get; } = item;
    }
}