namespace TvMaze.ShareCommon.Models.Settings
{
    /// <summary>
    /// Defines the <see cref="ConnectionStrings" />.
    /// </summary>
    public class ConnectionStrings
    {
        /// <summary>
        /// Gets or sets the Redis.
        /// </summary>
        public string Redis { get; set; }

        /// <summary>
        /// Gets or sets the SqlServer.
        /// </summary>
        public string SqlServer { get; set; }
    }
}