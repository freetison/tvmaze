namespace TvMaze.HttpWorker.Commands
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TvMaze.ShareCommon.Models.TvMaze;

    /// <summary>
    /// Defines the <see cref="PullCommand" />.
    /// </summary>
    public class PullCommand() : IAppCommand<string, List<ShowInfo?>>
    {
        /// <summary>
        /// The ExecuteAsync.
        /// </summary>
        /// <param name="input">The input<see cref="string"/>.</param>
        /// <returns>List{ShowInfo.</returns>
        public Task<List<ShowInfo?>> ExecuteAsync(string input)
        {
            throw new NotImplementedException();
        }
    }
}