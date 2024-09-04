namespace TvMaze.Application.Common.Models.Settings
{
    /// <summary>
    /// Defines the <see cref="ConnectionStrings" />.
    /// </summary>
    public class ConnectionStrings
    {
        /// <summary>
        /// Gets or sets the Redis.
        /// </summary>
        required public string Redis { get; set; }

        /// <summary>
        /// Gets or sets the SqlServer.
        /// </summary>
        required public string SqlServer { get; set; }
    }
}
