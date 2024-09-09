namespace TvMaze.HttpWorker.Workers
{
    using MediatR;
    using Polly;
    using TvMaze.HttpWorker.EventHandlers;
    using TvMaze.RabbitMqProvider;
    using TvMaze.ShareCommon.Models.Settings;

    /// <summary>
    /// Defines the <see cref="HttpServiceWorker" />.
    /// </summary>
    public class HttpServiceWorker(ILogger<HttpServiceWorker> logger, AppSettings appSettings, IMediator mediator, IRabbitMqClientProvider rabbitMqClient)
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
            if (string.IsNullOrEmpty(queueName))
            {
                logger.LogWarning("Queue name is not configured.");
                return;
            }

            var message = await rabbitMqClient.ReceiveMessage<string>(queueName);

            if (message != null)
            {
                logger.LogInformation("Received message from queue: {message}", message);
                await mediator.Publish(new QueueCommandsEvent(message), stoppingToken);
            }
        }
    }
}