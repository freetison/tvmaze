using MediatR;

using Microsoft.Extensions.Logging;

using TvMaze.Application.Features.TodoItems.Create.NotificationEvents;

namespace TvMaze.Application.Features.TodoItems.Create.EventHandlers;

internal sealed class TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger) : INotificationHandler<TodoItemCreatedEvent>
{
    private readonly ILogger<TodoItemCreatedEventHandler> _logger = logger;

    public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Domain Event triggered: {DomainEvent}", notification.Item);

        return Task.CompletedTask;
    }
}
