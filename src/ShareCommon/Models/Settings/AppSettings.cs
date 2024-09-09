namespace TvMaze.ShareCommon.Models.Settings
{
    using global::TvMaze.ShareCommon.Exceptions;
    using global::TvMaze.ShareCommon.Validators;

    /// <summary>
    /// Defines the <see cref="AppSettings" />.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Gets or sets the AppInfo.
        /// </summary>
        public AppInfo AppInfo { get; set; }

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

        /// <summary>
        /// The CheckyConfigurations.
        /// </summary>
        public void CheckConfigurations()
        {
            var validator = new AppSettingsValidator();
            FluentValidation.Results.ValidationResult result = validator.Validate(this);

            if (!result.IsValid)
            {
                throw new MissingConfigurationException();
            }
        }
    }
}