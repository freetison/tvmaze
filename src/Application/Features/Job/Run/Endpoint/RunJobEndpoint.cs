namespace TvMaze.Application.Features.Job.Run.Endpoint
{
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Routing;
    using TvMaze.Application.Features.Job.Run.EventHandlers;

    /// <summary>
    /// Defines the <see cref="RunJobEndpoint" />.
    /// </summary>
    public class RunJobEndpoint : IFeature
    {
        /// <summary>
        /// The MapEndpoints.
        /// </summary>
        /// <param name="endpoints">The endpoints<see cref="IEndpointRouteBuilder"/>.</param>
        /// <returns>The <see cref="IEndpointRouteBuilder"/>.</returns>
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("api/v1/run-job", async (IMediator mediator, RunJobCommand request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result);
            });

            return endpoints;
        }
    }
}
