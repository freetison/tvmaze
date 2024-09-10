namespace TvMaze.ShareCommon.Models.TvMaze
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="Rating" />.
    /// </summary>
    public class Rating
    {
        /// <summary>
        /// Gets or sets the Average.
        /// </summary>
        [JsonProperty("average")]
        public double Average { get; set; }
    }
}