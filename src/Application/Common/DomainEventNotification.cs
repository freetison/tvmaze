namespace TvMaze.Application.Common
{
    using MediatR;

    /// <summary>
    /// Defines the <see cref="DomainEventNotification{TDomainEvent}" />.
    /// </summary>
    /// <typeparam name="TDomainEvent">.</typeparam>
    public class DomainEventNotification<TDomainEvent> : INotification
    where TDomainEvent : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainEventNotification{TDomainEvent}"/> class.
        /// </summary>
        /// <param name="domainEvent">The domainEvent.</param>
        public DomainEventNotification(TDomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }

        /// <summary>
        /// Gets the DomainEvent.
        /// </summary>
        public TDomainEvent DomainEvent { get; }
    }
}