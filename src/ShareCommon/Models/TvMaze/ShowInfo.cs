namespace TvMaze.ShareCommon.Models.TvMaze
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="ShowInfo" />.
    /// </summary>
    public class ShowInfo
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Url.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the Language.
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the Genres.
        /// </summary>
        [JsonProperty("genres")]
        public List<string> Genres { get; set; }

        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the Runtime.
        /// </summary>
        [JsonProperty("runtime")]
        public int Runtime { get; set; }

        /// <summary>
        /// Gets or sets the AverageRuntime.
        /// </summary>
        [JsonProperty("averageRuntime")]
        public int AverageRuntime { get; set; }

        /// <summary>
        /// Gets or sets the Premiered.
        /// </summary>
        [JsonProperty("premiered")]
        public string Premiered { get; set; }

        /// <summary>
        /// Gets or sets the Ended.
        /// </summary>
        [JsonProperty("ended")]
        public string Ended { get; set; }

        /// <summary>
        /// Gets or sets the OfficialSite.
        /// </summary>
        [JsonProperty("officialSite")]
        public string OfficialSite { get; set; }

        /// <summary>
        /// Gets or sets the Schedule.
        /// </summary>
        [JsonProperty("schedule")]
        public Schedule Schedule { get; set; }

        /// <summary>
        /// Gets or sets the Rating.
        /// </summary>
        [JsonProperty("rating")]
        public Rating Rating { get; set; }

        /// <summary>
        /// Gets or sets the Weight.
        /// </summary>
        [JsonProperty("weight")]
        public int Weight { get; set; }

        /// <summary>
        /// Gets or sets the Network.
        /// </summary>
        [JsonProperty("network")]
        public Network Network { get; set; }

        /// <summary>
        /// Gets or sets the WebChannel.
        /// </summary>
        [JsonProperty("webChannel")]
        public object WebChannel { get; set; }

        /// <summary>
        /// Gets or sets the DvdCountry.
        /// </summary>
        [JsonProperty("dvdCountry")]
        public object DvdCountry { get; set; }

        /// <summary>
        /// Gets or sets the Externals.
        /// </summary>
        [JsonProperty("externals")]
        public Externals Externals { get; set; }

        /// <summary>
        /// Gets or sets the Image.
        /// </summary>
        [JsonProperty("image")]
        public Image Image { get; set; }

        /// <summary>
        /// Gets or sets the Summary.
        /// </summary>
        [JsonProperty("summary")]
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the Updated.
        /// </summary>
        [JsonProperty("updated")]
        public int Updated { get; set; }

        /// <summary>
        /// Gets or sets the Links.
        /// </summary>
        [JsonProperty("_links")]
        public Links Links { get; set; }
    }
}