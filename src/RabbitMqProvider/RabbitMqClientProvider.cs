namespace TvMaze.RabbitMqProvider
{
    using System.Text;

    using Microsoft.Extensions.Logging;

    using Newtonsoft.Json;

    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    using Tx.Core.Extensions.String;

    /// <summary>
    /// Defines the <see cref="RabbitMqClientProvider" />.
    /// </summary>
    public class RabbitMqClientProvider : IRabbitMqClientProvider, IDisposable
    {
        /// <summary>
        /// Defines the _logger.
        /// </summary>
        private readonly ILogger<RabbitMqClientProvider> _logger;

        /// <summary>
        /// Defines the _channel.
        /// </summary>
        private readonly IModel _channel;

        /// <summary>
        /// Initializes a new instance of the <see cref="RabbitMqClientProvider"/> class.
        /// </summary>
        /// <param name="logger">The logger<see cref="ILogger{RabbitMqClientProvider}"/>.</param>
        /// <param name="channel">The channel<see cref="IModel"/>.</param>
        public RabbitMqClientProvider(ILogger<RabbitMqClientProvider> logger, IModel channel)
        {
            _logger = logger;
            _channel = channel;
        }

        /// <summary>
        /// The ReceiveMessage.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="queueName">The queueName<see cref="string"/>.</param>
        /// <returns>The "T?"/>.</returns>
        public Task<T?> ReceiveMessage<T>(string queueName)
        {
            _channel.QueueDeclare(
                queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            T? receivedMessage = default;

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                receivedMessage = message.ParseTo<T?>();
            };

            _channel.BasicConsume(
                queue: queueName,
                autoAck: true,
                consumer: consumer);

            return Task.FromResult(receivedMessage ?? default);
        }

        /// <summary>
        /// The Dispose.
        /// </summary>
        public void Dispose()
        {
            _channel?.Dispose();
        }

        /// <summary>
        /// The PublishMessage.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="message">The message/>.</param>
        /// <param name="exchangeName">The exchangeName<see cref="string"/>.</param>
        /// <param name="routingKey">The routingKey<see cref="string"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public Task PublishMessage<T>(T message, string exchangeName, string routingKey)
        {
            try
            {
                _logger.LogDebug("Publishing message to Exchange: {ExchangeName} with Routing Key: {RoutingKey}", exchangeName, routingKey);

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                _channel.BasicPublish(
                    exchange: exchangeName,
                    routingKey: routingKey,
                    basicProperties: null,
                    body: body);

                _logger.LogInformation("Published Message to Exchange: {ExchangeName} with Routing Key: {RoutingKey}. Message: {Message}", exchangeName, routingKey, message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to publish message to Exchange: {ExchangeName} with Routing Key: {RoutingKey}", exchangeName, routingKey);
                throw;
            }

            return Task.CompletedTask;
        }
    }
}
