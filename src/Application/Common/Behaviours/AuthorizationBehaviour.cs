namespace TvMaze.Application.Common.Behaviours
{
    using System.Reflection;

    using MediatR;

    using TvMaze.Application.Common.Interfaces;
    using TvMaze.Application.Common.Security;

    /// <summary>
    /// Defines the <see cref="AuthorizationBehaviour{TRequest, TResponse}" />.
    /// </summary>
    /// <typeparam name="TRequest">.</typeparam>
    /// <typeparam name="TResponse">..</typeparam>
    public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        /// <summary>
        /// Defines the _currentUserService.
        /// </summary>
        private readonly ICurrentUserService _currentUserService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationBehaviour{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="currentUserService">The currentUserService<see cref="ICurrentUserService"/>.</param>
        public AuthorizationBehaviour(
        ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        /// <summary>
        /// The Handle.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="next">The next<see cref="RequestHandlerDelegate{TResponse}"/>.</param>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task{TResponse}"/>.</returns>
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

            if (authorizeAttributes.Any())
            {
                // Must be authenticated user
                if (_currentUserService.UserId == null)
                {
                    throw new UnauthorizedAccessException();
                }
            }

            // User is authorized / authorization not required
            return next();
        }
    }
}
