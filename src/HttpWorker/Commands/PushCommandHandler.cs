namespace TvMaze.HttpWorker.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TvMaze.ShareCommon.Models.TvMaze;

    /// <summary>
    /// Defines the <see cref="PushCommandHandler" />.
    /// </summary>
    public class PushCommandHandler : IRequestHandler<PushCommand, ShowInfo?>
    {
        /// <summary>
        /// The Handle.
        /// </summary>
        /// <param name="request">The request<see cref="PushCommand"/>.</param>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/>.</param>
        /// <returns>Task.</returns>
        public Task<ShowInfo?> Handle(PushCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}