namespace TvMaze.ShareCommon.Models.Settings
{
    /// <summary>
    /// Defines the <see cref="ExternalApi" />.
    /// </summary>
    public class ExternalApi
    {
        /// <summary>
        /// Gets or sets the BaseUrl.
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the Credentials.
        /// </summary>
        public Credentials? Credentials { get; set; }
    }
}