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
        public required string Redis { get; set; }

        /// <summary>
        /// Gets or sets the SqlServer.
        /// </summary>
        public required string SqlServer { get; set; }
    }
}
