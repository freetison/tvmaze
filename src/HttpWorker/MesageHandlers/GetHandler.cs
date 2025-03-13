namespace TvMaze.HttpWorker.MesageHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using TvMaze.ShareCommon.Models.Message;
    using TvMaze.ShareCommon.Models.TvMaze;

    /// <summary>
    /// Defines the <see cref="GetHandler" />.
    /// </summary>
    public class GetHandler : IMessageHandler<ShowInfo>
    {
        /// <summary>
        /// The Handle.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public Task HandleAsync(QueueMessage<ShowInfo> message, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Handling X message with action: {message.Name} and payload: {message.Payload}");

            return Task.CompletedTask;
        }
    }
}