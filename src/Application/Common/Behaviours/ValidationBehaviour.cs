namespace TvMaze.Application.Common.Behaviours
{
    using FluentValidation;

    using MediatR;

    /// <summary>
    /// Defines the <see cref="ValidationBehaviour{TRequest, TResponse}" />.
    /// </summary>
    /// <typeparam name="TRequest">.</typeparam>
    /// <typeparam name="TResponse">..</typeparam>
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        /// <summary>
        /// Defines the _validators.
        /// </summary>
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationBehaviour{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="validators">The validators"/>.</param>
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
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
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    throw new ValidationException(failures);
                }
            }

            return await next();
        }
    }
}