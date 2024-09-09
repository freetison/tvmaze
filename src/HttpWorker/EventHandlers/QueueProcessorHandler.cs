namespace TvMaze.HttpWorker.EventHandlers
{
    using MediatR;

    public class QueueProcessorHandler(ILogger<QueueProcessorHandler> logger)
    : INotificationHandler<QueueCommandsEvent>
    {
        private readonly ILogger _logger = logger;

        public Task Handle(QueueCommandsEvent notification, CancellationToken cancellationToken)
        {
            // using var scope = scopeFactory.CreateScope();
            // var rabbitMqClientProvider = scope.ServiceProvider.GetRequiredService<IMessageProducer>();
            // var message = new RabbitMqMessage<string>()
            // {
            //    TimeToLive = TimeSpan.FromMinutes(1),
            //    Body = notification.Data.ToJson()
            // };

            // await rabbitMqClientProvider.SendMessageAsync(message, "ExchangeMonitor");
            _logger.LogInformation($"Message {notification.Command} was processed");
            return Task.CompletedTask;
        }
    }
}