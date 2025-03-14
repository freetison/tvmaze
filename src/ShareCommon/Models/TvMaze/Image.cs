﻿namespace TvMaze.ShareCommon.Models.TvMaze
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="Image" />.
    /// </summary>
    public class Image
    {
        /// <summary>
        /// Gets or sets the Medium.
        /// </summary>
        [JsonProperty("medium")]
        public string Medium { get; set; }

        /// <summary>
        /// Gets or sets the Original.
        /// </summary>
        [JsonProperty("original")]
        public string Original { get; set; }
    }
}