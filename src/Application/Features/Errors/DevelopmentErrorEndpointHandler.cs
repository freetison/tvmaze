using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace TvMaze.Application.Features.Errors
{
    /// <summary>
    /// Handles error responses for endpoints.
    /// </summary>
    public class DevelopmentErrorEndpointHandler
    {
        /// <summary>
        /// Handles the error and returns the appropriate HTTP response.
        /// </summary>
        /// <param name="hostEnvironment">The hosting environment<see cref="IHostEnvironment"/>.</param>
        /// <param name="httpContextAccessor">The HTTP context accessor<see cref="IHttpContextAccessor"/>.</param>
        /// <returns>The <see cref="Task{IResult}"/>.</returns>
        public static Task<IResult> Handler(
            [FromServices] IHostEnvironment hostEnvironment,
            [FromServices] IHttpContextAccessor httpContextAccessor)
        {
            // Ensure we are in a development environment
            if (!hostEnvironment.IsDevelopment())
            {
                return Task.FromResult(Results.NotFound());
            }

            // Get the current HttpContext
            var httpContext = httpContextAccessor.HttpContext;

            // Ensure HttpContext is not null
            if (httpContext == null)
            {
                return Task.FromResult(Results.Problem("HttpContext is not available."));
            }

            // Get the exception handler feature from the HttpContext
            var exceptionHandlerFeature = httpContext.Features.Get<IExceptionHandlerFeature>();

            // Ensure the exception handler feature is not null
            if (exceptionHandlerFeature == null || exceptionHandlerFeature.Error == null)
            {
                return Task.FromResult(Results.Problem("An unexpected error occurred, but no further details are available."));
            }

            // Return the problem details with the exception information
            return Task.FromResult(Results.Problem(
                detail: exceptionHandlerFeature.Error.StackTrace,
                title: exceptionHandlerFeature.Error.Message));
        }
    }
}
