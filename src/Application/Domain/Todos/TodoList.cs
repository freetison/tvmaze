namespace TvMaze.Application.Domain.Todos
{
    using TvMaze.Application.Common;

    /// <summary>
    /// Defines the <see cref="TodoList" />.
    /// </summary>
    public class TodoList : AuditableEntity
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets the Items.
        /// </summary>
        public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
    }
}