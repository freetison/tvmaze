namespace TvMaze.ShareCommon.Models.TvMaze
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="Links" />.
    /// </summary>
    public class Links
    {
        /// <summary>
        /// Gets or sets the Self.
        /// </summary>
        [JsonProperty("self")]
        public Self Self { get; set; }

        /// <summary>
        /// Gets or sets the Previousepisode.
        /// </summary>
        [JsonProperty("previousepisode")]
        public Previousepisode Previousepisode { get; set; }
    }
}