namespace TvMaze.Application.Common.Behaviours
{
    using System.Diagnostics;

    using MediatR;

    using Microsoft.Extensions.Logging;

    using TvMaze.Application.Common.Interfaces;

    /// <summary>
    /// Defines the <see cref="PerformanceBehaviour{TRequest, TResponse}" />.
    /// </summary>
    /// <typeparam name="TRequest">.</typeparam>
    /// <typeparam name="TResponse">..</typeparam>
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        /// <summary>
        /// Defines the _currentUserService.
        /// </summary>
        private readonly ICurrentUserService _currentUserService;

        /// <summary>
        /// Defines the _logger.
        /// </summary>
        private readonly ILogger<TRequest> _logger;

        /// <summary>
        /// Defines the _timer.
        /// </summary>
        private readonly Stopwatch _timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceBehaviour{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="logger">The logger<see cref="ILogger{TRequest}"/>.</param>
        /// <param name="currentUserService">The currentUserService<see cref="ICurrentUserService"/>.</param>
        public PerformanceBehaviour(
        ILogger<TRequest> logger,
        ICurrentUserService currentUserService)
        {
            _timer = new Stopwatch();

            _logger = logger;
            _currentUserService = currentUserService;
        }

        /// <summary>
        /// The Handle.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="next">The next<see cref="RequestHandlerDelegate{TResponse}"/>.</param>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task{TResponse}"/>.</returns>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMilliseconds > 500)
            {
                var requestName = typeof(TRequest).Name;
                var userId = _currentUserService.UserId ?? string.Empty;

                _logger.LogWarning(
                    "VerticalSlice Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@Request}",
                    requestName,
                    elapsedMilliseconds,
                    userId,
                    request);
            }

            return response;
        }
    }
}