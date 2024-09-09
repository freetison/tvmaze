namespace TvMaze.HttpWorker.EventHandlers
{
    using MediatR;

    /// <summary>
    /// Defines the <see cref="QueueCommandsEvent" />.
    /// </summary>
    public class QueueCommandsEvent(string command) : INotification
    {
        /// <summary>
        /// Gets or sets the Command.
        /// </summary>
        public string Command { get; set; } = command;
    }
}