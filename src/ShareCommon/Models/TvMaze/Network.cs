namespace TvMaze.ShareCommon.Models.TvMaze
{
    /// <summary>
    /// Defines the <see cref="Network" />.
    /// </summary>
    public class Network
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        public Country? Country { get; set; }

        /// <summary>
        /// Gets or sets the OfficialSite.
        /// </summary>
        public string? OfficialSite { get; set; }
    }
}