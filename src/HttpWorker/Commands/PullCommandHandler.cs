namespace TvMaze.HttpWorker.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TvMaze.ShareCommon.Models.TvMaze;

    /// <summary>
    /// Defines the <see cref="PullCommandHandler" />.
    /// </summary>
    public class PullCommandHandler : IRequestHandler<PullCommand, List<ShowInfo?>>
    {
        public Task<List<ShowInfo?>> Handle(PullCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}