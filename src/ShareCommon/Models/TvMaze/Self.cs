namespace TvMaze.ShareCommon.Models.TvMaze
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="Self" />.
    /// </summary>
    public class Self
    {
        /// <summary>
        /// Gets or sets the Href.
        /// </summary>
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}