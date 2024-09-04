namespace TvMaze.Application.Common.Behaviours
{
    using MediatR.Pipeline;

    using Microsoft.Extensions.Logging;

    using TvMaze.Application.Common.Interfaces;

    /// <summary>
    /// Defines the <see cref="LoggingBehaviour{TRequest}" />.
    /// </summary>
    /// <typeparam name="TRequest">.</typeparam>
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    where TRequest : notnull
    {
        /// <summary>
        /// Defines the _logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Defines the _currentUserService.
        /// </summary>
        private readonly ICurrentUserService _currentUserService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingBehaviour{TRequest}"/> class.
        /// </summary>
        /// <param name="logger">The logger<see cref="ILogger{TRequest}"/>.</param>
        /// <param name="currentUserService">The currentUserService<see cref="ICurrentUserService"/>.</param>
        public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
        }

        /// <summary>
        /// The Process.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUserService.UserId ?? string.Empty;

            return Task.Run(
                () => _logger.LogInformation(
                "VerticalSlice Request: {Name} {@UserId} {@Request}",
                requestName,
                userId,
                request),
                cancellationToken);
        }
    }
}