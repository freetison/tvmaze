namespace TvMaze.ShareCommon.Models.TvMaze
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="Schedule" />.
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// Gets or sets the Time.
        /// </summary>
        [JsonProperty("time")]
        public string Time { get; set; }

        /// <summary>
        /// Gets or sets the Days.
        /// </summary>
        [JsonProperty("days")]
        public List<string> Days { get; set; }
    }
}