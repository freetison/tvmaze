namespace TvMaze.Api.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using TvMaze.Application.Common.Exceptions;

    /// <summary>
    /// Defines the <see cref="ApiExceptionFilterAttribute" />.
    /// </summary>
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Defines the _exceptionHandlers.
        /// </summary>
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiExceptionFilterAttribute"/> class.
        /// </summary>
        public ApiExceptionFilterAttribute()
        {
            // Register known exception types and handlers.
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
        {
            { typeof(ValidationException), HandleValidationException },
            { typeof(NotFoundException), HandleNotFoundException },
            { typeof(UnauthorizedAccessException), HandleUnauthorizedAccessException },
            { typeof(ForbiddenAccessException), HandleForbiddenAccessException },
        };
        }

        /// <summary>
        /// The OnException.
        /// </summary>
        /// <param name="context">The context<see cref="ExceptionContext"/>.</param>
        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        /// <summary>
        /// The HandleException.
        /// </summary>
        /// <param name="context">The context<see cref="ExceptionContext"/>.</param>
        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            if (!context.ModelState.IsValid)
            {
                HandleInvalidModelStateException(context);
                return;
            }

            HandleUnknownException(context);
        }

        /// <summary>
        /// The HandleValidationException.
        /// </summary>
        /// <param name="context">The context<see cref="ExceptionContext"/>.</param>
        private void HandleValidationException(ExceptionContext context)
        {
            ValidationException? exception = context.Exception as ValidationException;

            ValidationProblemDetails details = new(exception!.Errors)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            };

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }

        /// <summary>
        /// The HandleInvalidModelStateException.
        /// </summary>
        /// <param name="context">The context<see cref="ExceptionContext"/>.</param>
        private void HandleInvalidModelStateException(ExceptionContext context)
        {
            ValidationProblemDetails details = new(context.ModelState)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            };

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }

        /// <summary>
        /// The HandleNotFoundException.
        /// </summary>
        /// <param name="context">The context<see cref="ExceptionContext"/>.</param>
        private void HandleNotFoundException(ExceptionContext context)
        {
            NotFoundException? exception = context.Exception as NotFoundException;

            ProblemDetails details = new()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "The specified resource was not found.",
                Detail = exception!.Message,
            };

            context.Result = new NotFoundObjectResult(details);

            context.ExceptionHandled = true;
        }

        /// <summary>
        /// The HandleUnauthorizedAccessException.
        /// </summary>
        /// <param name="context">The context<see cref="ExceptionContext"/>.</param>
        private void HandleUnauthorizedAccessException(ExceptionContext context)
        {
            ProblemDetails details = new()
            {
                Status = StatusCodes.Status401Unauthorized,
                Title = "Unauthorized",
                Type = "https://tools.ietf.org/html/rfc7235#section-3.1",
            };

            context.Result = new ObjectResult(details) { StatusCode = StatusCodes.Status401Unauthorized };

            context.ExceptionHandled = true;
        }

        /// <summary>
        /// The HandleForbiddenAccessException.
        /// </summary>
        /// <param name="context">The context<see cref="ExceptionContext"/>.</param>
        private void HandleForbiddenAccessException(ExceptionContext context)
        {
            ProblemDetails details = new()
            {
                Status = StatusCodes.Status403Forbidden,
                Title = "Forbidden",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3",
            };

            context.Result = new ObjectResult(details) { StatusCode = StatusCodes.Status403Forbidden };

            context.ExceptionHandled = true;
        }

        /// <summary>
        /// The HandleUnknownException.
        /// </summary>
        /// <param name="context">The context<see cref="ExceptionContext"/>.</param>
        private void HandleUnknownException(ExceptionContext context)
        {
            ProblemDetails details = new()
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error occurred while processing your request.",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            };

            context.Result = new ObjectResult(details) { StatusCode = StatusCodes.Status500InternalServerError };

            context.ExceptionHandled = true;
        }
    }
}