namespace TvMaze.HttpWorker.Feature.Pull
{
    using MediatR;
    using TvMaze.ShareCommon.Models.TvMaze;

    public class PullDataCommandHandler(ILogger<PullDataCommandHandler> logger) : IRequestHandler<PullDataCommand, List<ShowInfo?>>
    {
        public Task<List<ShowInfo?>> Handle(PullDataCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("PullDataCommandHandler: {CommandName}", request.CommandName);
            return Task.FromResult<List<ShowInfo?>>(new List<ShowInfo?>());
        }
    }
}