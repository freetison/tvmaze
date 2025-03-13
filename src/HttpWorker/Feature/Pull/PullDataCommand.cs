namespace TvMaze.HttpWorker.Feature.Pull
{
    using MediatR;
    using TvMaze.ShareCommon.Models.TvMaze;

    /// <summary>
    /// Defines the <see cref="PullDataCommand" />.
    /// </summary>
    public class PullDataCommand : IRequest<List<ShowInfo?>>
    {
        /// <summary>
        /// Gets or sets the CommandName.
        /// </summary>
        public string CommandName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PullDataCommand"/> class.
        /// </summary>
        /// <param name="commandName">The commandName<see cref="string"/>.</param>
        public PullDataCommand(string commandName)
        {
            CommandName = commandName;
        }
    }
}