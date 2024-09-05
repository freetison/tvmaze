namespace TvMaze.ShareCommon.Models.TvMaze
{
    /// <summary>
    /// Defines the <see cref="Show" />.
    /// </summary>
    public class Show
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
        /// Gets or sets the Language.
        /// </summary>
        public string? Language { get; set; }

        /// <summary>
        /// Gets or sets the Genres.
        /// </summary>
        public string[]? Genres { get; set; }

        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// Gets or sets the Runtime.
        /// </summary>
        public int Runtime { get; set; }

        /// <summary>
        /// Gets or sets the Rating.
        /// </summary>
        public double? Rating { get; set; }

        /// <summary>
        /// Gets or sets the Summary.
        /// </summary>
        public string? Summary { get; set; }

        /// <summary>
        /// Gets or sets the Premiered.
        /// </summary>
        public string? Premiered { get; set; }

        /// <summary>
        /// Gets or sets the Ended.
        /// </summary>
        public string? Ended { get; set; }

        /// <summary>
        /// Gets or sets the Schedule.
        /// </summary>
        public Schedule? Schedule { get; set; }

        /// <summary>
        /// Gets or sets the Network.
        /// </summary>
        public Network? Network { get; set; }

        /// <summary>
        /// Gets or sets the Externals.
        /// </summary>
        public Externals? Externals { get; set; }

        /// <summary>
        /// Gets or sets the Image.
        /// </summary>
        public Image? Image { get; set; }

        /// <summary>
        /// Gets or sets the Links.
        /// </summary>
        public Links? Links { get; set; }

        /// <summary>
        /// Gets or sets the OfficialSite.
        /// </summary>
        public string? OfficialSite { get; set; }
    }
}