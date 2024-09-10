namespace TvMaze.HttpWorker.Commands
{
    using System.Threading.Tasks;

    using TvMaze.ShareCommon.Models.TvMaze;

    /// <summary>
    /// Defines the <see cref="PushCommand" />.
    /// </summary>
    public class PushCommand : AppCommand<string, ShowInfo?>
    {
        /// <summary>
        /// The ProcessAsync.
        /// </summary>
        /// <param name="input">The input<see cref="string"/>.</param>
        /// <returns>The task.</returns>
        public override Task<ShowInfo?> ProcessAsync(string input)
        {
            return Task.FromResult<ShowInfo?>(null);
        }
    }
}