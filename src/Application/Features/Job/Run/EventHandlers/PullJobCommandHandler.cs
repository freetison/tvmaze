namespace TvMaze.Application.Features.Job.Run.EventHandlers
{
    using MediatR;

    using TvMaze.RabbitMqProvider;

    /// <summary>
    /// Defines the <see cref="PullJobCommandHandler" />.
    /// </summary>
    public class PullJobCommandHandler : IRequestHandler<RunJobCommand, Unit>
    {
        private const string RoutingKey = "CommandQueue";

        /// <summary>
        /// Defines the _messageClientProvider.
        /// </summary>
        private readonly IRabbitMqClientProvider _messageClientProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="PullJobCommandHandler"/> class.
        /// </summary>
        /// <param name="messageClientProvider">The messageClientProvider<see cref="IRabbitMqClientProvider"/>.</param>
        public PullJobCommandHandler(IRabbitMqClientProvider messageClientProvider)
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
            // var message = new QueueMessage<string>("PullCommand", "PULL");
            _messageClientProvider.PublishMessage("PULL", "amq.direct", RoutingKey);
            return Task.FromResult(Unit.Value);
        }
    }

    public record RunJobCommand() : IRequest<Unit>;
}