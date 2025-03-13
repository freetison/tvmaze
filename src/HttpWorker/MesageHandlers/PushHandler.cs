namespace TvMaze.HttpWorker.MesageHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using TvMaze.ShareCommon.Models.Message;

    /// <summary>
    /// Defines the <see cref="PushHandler" />.
    /// </summary>
    public class PushHandler : IMessageHandler<string>
    {
        /// <summary>
        /// The HandleAsync.
        /// </summary>
        /// <param name="message">The message<see cref="QueueMessage{ShowInfo}"/>.</param>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public Task HandleAsync(QueueMessage<string> message, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Handling X message with action: {message.Name} and payload: {message.Payload}");

            return Task.CompletedTask;
        }
    }
}