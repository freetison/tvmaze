namespace TvMaze.Application.Common.Models.Settings
{
    using System.Diagnostics.CodeAnalysis;

    using TvMaze.RabbitMqProvider;

    /// <summary>
    /// Defines the <see cref="ApiSettings" />.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ApiSettings
    {
        /// <summary>
        /// Gets or sets the ApiTitle.
        /// </summary>
        required public string ApiTitle { get; set; }

        /// <summary>
        /// Gets or sets the ApiVersion.
        /// </summary>
        required public string ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets the ApiDescription.
        /// </summary>
        public string? ApiDescription { get; set; }

        /// <summary>
        /// Gets or sets the ConnectionStrings.
        /// </summary>
        required public ConnectionStrings ConnectionStrings { get; set; }

        /// <summary>
        /// Gets or sets the ExternalApi.
        /// </summary>
        required public ExternalApi ExternalApi { get; set; }

        /// <summary>
        /// Gets or sets the Options.
        /// </summary>
        required public Options Options { get; set; }

        /// <summary>
        /// Gets or sets the RabbitMqSettings.
        /// </summary>
        required public RabbitMqSettings RabbitMq { get; set; }
    }
}
