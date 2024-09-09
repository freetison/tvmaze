namespace TvMaze.ShareCommon.Models.Settings
{
    /// <summary>
    /// Defines the <see cref="RabbitMqSettings" />.
    /// </summary>
    public class RabbitMqSettings
    {
        /// <summary>
        /// Gets or sets the RabbitMqHostName.
        /// </summary>
        public string RabbitMqHostName { get; set; }

        /// <summary>
        /// Gets or sets the RabbitMqPort.
        /// </summary>
        public int? RabbitMqPort { get; set; } = 15672;

        /// <summary>
        /// Gets or sets the RabbitMqConcurrency.
        /// </summary>
        public int? RabbitMqConcurrency { get; set; } = 50;

        /// <summary>
        /// Gets or sets the RabbitMqUserName.
        /// </summary>
        public string RabbitMqUserName { get; set; }

        /// <summary>
        /// Gets or sets the RabbitMqPassword.
        /// </summary>
        public string RabbitMqPassword { get; set; }

        /// <summary>
        /// Gets or sets the ExchangeName.
        /// </summary>
        public string ExchangeName { get; set; } = "amq.direct";

        /// <summary>
        /// Gets or sets the RabbitMqQueueName.
        /// </summary>
        public string RabbitMqQueueName { get; set; }
    }
}