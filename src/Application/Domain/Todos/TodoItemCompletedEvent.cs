namespace TvMaze.Application.Domain.Todos
{
    using TvMaze.Application.Common;

    /// <summary>
    /// Defines the <see cref="TodoItemCompletedEvent" />.
    /// </summary>
    internal sealed class TodoItemCompletedEvent(TodoItem item) : DomainEvent
    {
        /// <summary>
        /// Gets the Item.
        /// </summary>
        public TodoItem Item { get; } = item;
    }
}
