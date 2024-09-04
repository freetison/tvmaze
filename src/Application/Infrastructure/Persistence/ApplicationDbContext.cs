namespace TvMaze.Application.Infrastructure.Persistence
{
    using System.Reflection;

    using Microsoft.EntityFrameworkCore;

    using TvMaze.Application.Common;
    using TvMaze.Application.Common.Interfaces;
    using TvMaze.Application.Domain.Todos;

    /// <summary>
    /// Defines the <see cref="ApplicationDbContext" />.
    /// </summary>
    public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options,
    ICurrentUserService currentUserService,
    IDomainEventService domainEventService,
    IDateTime dateTime) : DbContext(options)
    {
        /// <summary>
        /// Defines the _currentUserService.
        /// </summary>
        private readonly ICurrentUserService _currentUserService = currentUserService;

        /// <summary>
        /// Defines the _dateTime.
        /// </summary>
        private readonly IDateTime _dateTime = dateTime;

        /// <summary>
        /// Defines the _domainEventService.
        /// </summary>
        private readonly IDomainEventService _domainEventService = domainEventService;

        /// <summary>
        /// Gets the TodoLists.
        /// </summary>
        public DbSet<TodoList> TodoLists => Set<TodoList>();

        /// <summary>
        /// Gets the TodoItems.
        /// </summary>
        public DbSet<TodoItem> TodoItems => Set<TodoItem>();

        /// <summary>
        /// The SaveChangesAsync.
        /// </summary>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/>.</param>
        /// <returns>The task.</returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    default:
                        break;
                }
            }

            var events = ChangeTracker.Entries<IHasDomainEvent>()
                    .Select(x => x.Entity.DomainEvents)
                    .SelectMany(x => x)
                    .Where(domainEvent => !domainEvent.IsPublished)
                    .ToArray();

            var result = await base.SaveChangesAsync(cancellationToken);

            await DispatchEvents(events);
            return result;
        }

        /// <summary>
        /// The OnModelCreating.
        /// </summary>
        /// <param name="builder">The builder<see cref="ModelBuilder"/>.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        /// <summary>
        /// The DispatchEvents.
        /// </summary>
        /// <param name="events">The events.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        private async Task DispatchEvents(DomainEvent[] events)
        {
            foreach (var @event in events)
            {
                @event.IsPublished = true;
                await _domainEventService.Publish(@event);
            }
        }
    }
}
