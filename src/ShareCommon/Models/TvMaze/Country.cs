namespace TvMaze.ShareCommon.Models.TvMaze
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="Country" />.
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the Timezone.
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }
}