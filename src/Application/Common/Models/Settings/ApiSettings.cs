namespace TvMaze.Application.Common.Models.Settings
{
    using System.Diagnostics.CodeAnalysis;
    using TvMaze.RabbitMqProvider.Models;

    /// <summary>
    /// Defines the <see cref="ApiSettings" />.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ApiSettings
    {
        /// <summary>
        /// Gets or sets the ApiTitle.
        /// </summary>
        public string? ApiTitle { get; set; }

        /// <summary>
        /// Gets or sets the ApiVersion.
        /// </summary>
        public string? ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets the ApiDescription.
        /// </summary>
        public string? ApiDescription { get; set; }

        /// <summary>
        /// Gets or sets the ConnectionStrings.
        /// </summary>
        public ConnectionStrings ConnectionStrings { get; set; }

        /// <summary>
        /// Gets or sets the ExternalApi.
        /// </summary>
        public ExternalApi ExternalApi { get; set; }

        /// <summary>
        /// Gets or sets the Options.
        /// </summary>
        public Options Options { get; set; }

        /// <summary>
        /// Gets or sets the RabbitMq.
        /// </summary>
        public RabbitMqSettings RabbitMq { get; set; }
    }
}