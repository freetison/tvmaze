namespace TvMaze.HttpWorker.EventHandlers
{
    using MediatR;

    public class SaveDataEventHandler(ILogger<SaveDataEventHandler> logger, IServiceScopeFactory scopeFactory)
    : INotificationHandler<DataReadEvent>
    {
        public Task Handle(DataReadEvent notification, CancellationToken cancellationToken)
        {
            if (notification.Data == null)
            {
                return Task.CompletedTask;
            }

            using var scope = scopeFactory.CreateScope();

            // var rabbitMqClientProvider = scope.ServiceProvider.GetRequiredService<IMessageProducer>();
            // var message = new RabbitMqMessage<string>()
            // {
            //    TimeToLive = TimeSpan.FromMinutes(1),
            //    Body = notification.Data.ToJson()
            // };
            logger.LogInformation($"{notification.Data?.Name} was processed");
            return Task.CompletedTask;
        }
    }
}