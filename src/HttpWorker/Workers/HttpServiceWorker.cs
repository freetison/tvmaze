namespace TvMaze.HttpWorker.Workers
{
    using System.Reflection;
    using System.Text.Json;
    using Polly;
    using TvMaze.RabbitMqProvider;
    using TvMaze.ShareCommon.Models.Message;
    using TvMaze.ShareCommon.Models.Settings;

    /// <summary>
    /// Defines the <see cref="HttpServiceWorker" />.
    /// </summary>
    public class HttpServiceWorker(ILogger<HttpServiceWorker> logger, AppSettings appSettings, IRabbitMqClientProvider rabbitMqClient, IServiceProvider serviceProvider)
        : BackgroundService
    {
        /// <summary>
        /// The ExecuteAsync.
        /// </summary>
        /// <param name="stoppingToken">The stoppingToken<see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Policy
                .HandleResult<bool>(c => c == false)
                .WaitAndRetryForeverAsync(_ => TimeSpan.FromSeconds(appSettings.Options.RequestRateSeconds))
                .ExecuteAsync(async () =>
                {
                    await BackgroundProcessing(stoppingToken);
                    return false;
                });
        }

        /// <summary>
        /// The BackgroundProcessing.
        /// </summary>
        /// <param name="stoppingToken">The stoppingToken<see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        private async Task BackgroundProcessing(CancellationToken stoppingToken)
        {
            var queueName = appSettings.RabbitMq.RabbitMqQueueName;

            // var message = await rabbitMqClient.ReceiveMessage<QueueMessage<object>>(queueName);
            var message = await rabbitMqClient.ReceiveMessage<string>(queueName);

            logger.LogInformation(message == null ? "Received null message from queue" : "Received message from queue: {message}", message);

            // var pp = DeserializeMessage(, typeof(Order));

            // var (handler, method) = GetServiceMethod(message);
            // method?.Invoke(handler, new object[] { message!, stoppingToken });
        }

        /// <summary>
        /// The GetServiceMethod.
        /// </summary>
        /// <param name="message">.</param>
        /// <returns>The tuplehandler, MethodInfo.</returns>
        private (object? handler, MethodInfo? method) GetServiceMethod(QueueMessage<object>? message)
        {
            var payloadType = message?.Payload?.GetType();
            var messageType = message?.GetType();
            logger.LogError(payloadType is null ? "Message payload is null or unknown" : $"Message payload type is {payloadType.Name}");

            var pp = serviceProvider.GetService(typeof(IMessageHandler<string>));
            var handlerType = typeof(IMessageHandler<>).MakeGenericType(messageType ?? throw new ArgumentNullException(nameof(message)));
            var handler = serviceProvider.GetService(handlerType) ?? throw new InvalidOperationException($"No handler found for payload type {payloadType?.Name ?? "unknown"}");

            var method = handlerType.GetMethod("Handle");
            logger.LogError(method is null ? "No method found for handling the message" : $"Method found for handling the message: {method}");

            return (handler, method);
        }

        private static QueueMessage<T>? DeserializeMessage<T>(string json, Type payloadType)
        {
            // Creamos las opciones de deserialización
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            // Usamos reflection para construir el tipo genérico QueueMessage<T>
            var queueMessageType = typeof(QueueMessage<>).MakeGenericType(payloadType);

            // Deserializamos el objeto
            var message = JsonSerializer.Deserialize(json, queueMessageType, options) as QueueMessage<T>;

            return message;
        }
    }
}