namespace TvMaze.HttpWorker.Workers
{
    using MediatR;
    using Polly;
    using TvMaze.HttpWorker.Commands;
    using TvMaze.HttpWorker.EventHandlers;
    using TvMaze.RabbitMqProvider;
    using TvMaze.ShareCommon.Models.Settings;
    using TvMaze.ShareCommon.Models.TvMaze;
    using Tx.Core.GenericFactory;

    /// <summary>
    /// Defines the <see cref="HttpServiceWorker" />.
    /// </summary>
    public class HttpServiceWorker(ILogger<HttpServiceWorker> logger, AppSettings appSettings, IMediator mediator, IRabbitMqClientProvider rabbitMqClient, IServiceScopeFactory scopeFactory)
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
            var message = await rabbitMqClient.ReceiveMessage<string>(queueName);

            if (message != null)
            {
                logger.LogInformation("Received message from queue: {message}", message);
                using var scope = scopeFactory.CreateScope();
                var factory = scope.ServiceProvider.GetRequiredService<GenericFactory<string, IAppCommand<string, ShowInfo?>>>();
                var commandProcessor = factory.Get(message);
                var result = await commandProcessor.ProcessAsync(message);

                await mediator.Publish(new DataReadEvent(result), stoppingToken);
            }
        }
    }
}