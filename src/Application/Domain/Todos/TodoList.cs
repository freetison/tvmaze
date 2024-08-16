using TvMaze.Application.Common;

namespace TvMaze.Application.Domain.Todos;

public class TodoList : AuditableEntity
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
}
