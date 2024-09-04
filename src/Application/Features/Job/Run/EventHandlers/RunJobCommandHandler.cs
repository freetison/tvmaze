namespace TvMaze.Application.Features.Job.Run.EventHandlers
{
    using MediatR;

    using TvMaze.RabbitMqProvider;

    /// <summary>
    /// Defines the <see cref="RunJobCommandHandler" />.
    /// </summary>
    public class RunJobCommandHandler : IRequestHandler<RunJobCommand, Unit>
    {
        /// <summary>
        /// Defines the _messageClientProvider.
        /// </summary>
        private readonly IRabbitMqClientProvider _messageClientProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="RunJobCommandHandler"/> class.
        /// </summary>
        /// <param name="messageClientProvider">The messageClientProvider<see cref="IRabbitMqClientProvider"/>.</param>
        public RunJobCommandHandler(IRabbitMqClientProvider messageClientProvider)
        {
            _messageClientProvider = messageClientProvider;
        }

        /// <summary>
        /// The Handle.
        /// </summary>
        /// <param name="request">The request<see cref="RunJobCommand"/>.</param>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task{Unit}"/>.</returns>
        public Task<Unit> Handle(RunJobCommand request, CancellationToken cancellationToken)
        {
            _messageClientProvider.PublishMessage<string>("PULL", "amq.direct", "ServiceBus");
            return Task.FromResult(Unit.Value);
        }
    }

    public record RunJobCommand() : IRequest<Unit>;
}
