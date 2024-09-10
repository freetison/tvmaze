namespace TvMaze.HttpWorker.EventHandlers
{
    using MediatR;

    using TvMaze.ShareCommon.Models.TvMaze;

    /// <summary>
    /// Defines the <see cref="DataReadEvent" />.
    /// </summary>
    public class DataReadEvent(ShowInfo? data) : INotification
    {
        /// <summary>
        /// Gets or sets the Command.
        /// </summary>
        public ShowInfo? Data { get; set; } = data;
    }
}