namespace TvMaze.ShareCommon.Models.Message
{
    /// <summary>
    /// Defines the <see cref="QueueMessage{T}" />.
    /// </summary>
    /// <param name="Name"> Gets or sets the Name. </param>
    /// <param name="Payload"> Gets or sets the Payload. </param>
    /// <typeparam name="T">.</typeparam>
    public record QueueMessage<T>(string Name, T Payload);
}