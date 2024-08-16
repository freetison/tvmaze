using TvMaze.Application.Common;

namespace TvMaze.Application.Domain.Todos;

internal sealed class TodoItemDeletedEvent(TodoItem item) : DomainEvent
{
    public TodoItem Item { get; } = item;
}