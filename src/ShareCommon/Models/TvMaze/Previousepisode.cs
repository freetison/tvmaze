namespace TvMaze.ShareCommon.Models.TvMaze
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="Previousepisode" />.
    /// </summary>
    public class Previousepisode
    {
        /// <summary>
        /// Gets or sets the Href.
        /// </summary>
        [JsonProperty("href")]
        public string Href { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}