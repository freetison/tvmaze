using Microsoft.AspNetCore.Http;

namespace TvMaze.Application.Features.Errors
{
    /// <summary>
    /// Handles error responses for endpoints.
    /// </summary>
    public class ErrorEndpointHandler
    {
        /// <summary>
        /// Handles the error and returns the appropriate HTTP response.
        /// </summary>
        /// <returns>The <see cref="Task{IResult}"/>.</returns>
        public static Task<IResult> Handler()
        {
            // Ensure we are in a development environment

            // Return the problem details with the exception information
            return Task.FromResult(Results.Problem());
        }
    }
}
