namespace TvMaze.ShareCommon.Models.TvMaze
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="Network" />.
    /// </summary>
    public class Network
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        [JsonProperty("country")]
        public Country Country { get; set; }

        /// <summary>
        /// Gets or sets the OfficialSite.
        /// </summary>
        [JsonProperty("officialSite")]
        public string OfficialSite { get; set; }
    }
}