namespace TvMaze.Application.Domain.Todos
{
    using TvMaze.Application.Common;

    /// <summary>
    /// Defines the <see cref="TodoItemCreatedEvent" />.
    /// </summary>
    internal sealed class TodoItemCreatedEvent(TodoItem item) : DomainEvent
    {
        /// <summary>
        /// Gets the Item.
        /// </summary>
        public TodoItem Item { get; } = item;
    }
}
