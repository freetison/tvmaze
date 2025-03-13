namespace TvMaze.ShareCommon.Models.Message
{
    public interface IMessageService<T>
    {
        Task ProcessMessageAsync(QueueMessage<T> message, CancellationToken cancellationToken);
    }
}