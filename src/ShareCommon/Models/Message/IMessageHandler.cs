namespace TvMaze.ShareCommon.Models.Message
{
    /// <summary>
    /// Defines the <see cref="IMessageHandler{T}" />.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public interface IMessageHandler<T>
    {
        /// <summary>
        /// The Handle.
        /// </summary>
        /// <param name="message">The message<see cref="QueueMessage{T}"/>.</param>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task HandleAsync(QueueMessage<T> message, CancellationToken cancellationToken);
    }
}