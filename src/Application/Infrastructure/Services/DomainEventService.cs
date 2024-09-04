namespace TvMaze.Application.Infrastructure.Services
{
    using MediatR;

    using Microsoft.Extensions.Logging;

    using TvMaze.Application.Common;
    using TvMaze.Application.Common.Interfaces;

    /// <summary>
    /// Defines the <see cref="DomainEventService" />.
    /// </summary>
    public class DomainEventService : IDomainEventService
    {
        /// <summary>
        /// Defines the _logger.
        /// </summary>
        private readonly ILogger<DomainEventService> _logger;

        /// <summary>
        /// Defines the _mediator.
        /// </summary>
        private readonly IPublisher _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainEventService"/> class.
        /// </summary>
        /// <param name="logger">The logger<see cref="ILogger{DomainEventService}"/>.</param>
        /// <param name="mediator">The mediator<see cref="IPublisher"/>.</param>
        public DomainEventService(ILogger<DomainEventService> logger, IPublisher mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// The Publish.
        /// </summary>
        /// <param name="domainEvent">The domainEvent<see cref="DomainEvent"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public Task Publish(DomainEvent domainEvent)
        {
            _logger.LogInformation("Publishing domain event. Event - {event}", domainEvent.GetType().Name);
            return _mediator.Publish(GetNotificationCorrespondingToDomainEvent(domainEvent));
        }

        /// <summary>
        /// The GetNotificationCorrespondingToDomainEvent.
        /// </summary>
        /// <param name="domainEvent">The domainEvent<see cref="DomainEvent"/>.</param>
        /// <returns>The <see cref="INotification"/>.</returns>
        private INotification GetNotificationCorrespondingToDomainEvent(DomainEvent domainEvent)
        {
            return (INotification)Activator.CreateInstance(
                typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()), domainEvent)!;
        }
    }
}
