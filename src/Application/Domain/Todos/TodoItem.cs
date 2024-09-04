namespace TvMaze.Application.Domain.Todos
{
    using TvMaze.Application.Common;

    /// <summary>
    /// Defines the <see cref="TodoItem" />.
    /// </summary>
    public class TodoItem : AuditableEntity, IHasDomainEvent
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ListId.
        /// </summary>
        public int ListId { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the Note.
        /// </summary>
        public string? Note { get; set; }

        /// <summary>
        /// Gets or sets the Priority.
        /// </summary>
        public PriorityLevel Priority { get; set; }

        /// <summary>
        /// Gets or sets the Reminder.
        /// </summary>
        public DateTime? Reminder { get; set; }

        /// <summary>
        /// Defines the _done.
        /// </summary>
        private bool _done;

        /// <summary>
        /// Gets or sets a value indicating whether Done.
        /// </summary>
        public bool Done
        {
            get => _done;
            set
            {
                if (value && _done == false)
                {
                    DomainEvents.Add(new TodoItemCompletedEvent(this));
                }

                _done = value;
            }
        }

        /// <summary>
        /// Gets or sets the List.
        /// </summary>
        public TodoList List { get; set; } = null!;

        /// <summary>
        /// Gets the DomainEvents.
        /// </summary>
        public List<DomainEvent> DomainEvents { get; } = new List<DomainEvent>();
    }
}

/// <summary>
/// Defines the PriorityLevel.
/// </summary>
public enum PriorityLevel
{
    /// <summary>
    /// Defines the None.
    /// </summary>
    None = 0,

    /// <summary>
    /// Defines the Low.
    /// </summary>
    Low = 1,

    /// <summary>
    /// Defines the Medium.
    /// </summary>
    Medium = 2,

    /// <summary>
    /// Defines the High.
    /// </summary>
    High = 3,
}

public record TodoItemRecord(string? Title, bool Done);