using TvMaze.Application.Common;

namespace TvMaze.Application.Domain.Todos;

internal sealed class TodoItemCreatedEvent(TodoItem item) : DomainEvent
{
    public TodoItem Item { get; } = item;
}