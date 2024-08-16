using System.Diagnostics.CodeAnalysis;

namespace TvMaze.Application.Common.Models.Settings
{
    /// <summary>
    /// Defines the <see cref="ApiSettings" />.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ApiSettings
    {
        /// <summary>
        /// Gets or sets the ApiTitle.
        /// </summary>
        public required string ApiTitle { get; set; }

        /// <summary>
        /// Gets or sets the ApiVersion.
        /// </summary>
        public required string ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets the ApiDescription.
        /// </summary>
        public string? ApiDescription { get; set; }

        /// <summary>
        /// Gets or sets the ConnectionStrings.
        /// </summary>
        public required ConnectionStrings ConnectionStrings { get; set; }

        /// <summary>
        /// Gets or sets the ExternalApi.
        /// </summary>
        public required ExternalApi ExternalApi { get; set; }

        /// <summary>
        /// Gets or sets the Options.
        /// </summary>
        public required Options Options { get; set; }
    }
}
