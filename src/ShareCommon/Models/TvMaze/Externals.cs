namespace TvMaze.ShareCommon.Models.TvMaze
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="Externals" />.
    /// </summary>
    public class Externals
    {
        /// <summary>
        /// Gets or sets the Tvrage.
        /// </summary>
        [JsonProperty("tvrage")]
        public int Tvrage { get; set; }

        /// <summary>
        /// Gets or sets the Thetvdb.
        /// </summary>
        [JsonProperty("thetvdb")]
        public int Thetvdb { get; set; }

        /// <summary>
        /// Gets or sets the Imdb.
        /// </summary>
        [JsonProperty("imdb")]
        public string Imdb { get; set; }
    }
}