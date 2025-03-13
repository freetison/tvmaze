namespace TvMaze.HttpWorker.Commands
{
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="PushCommand" />.
    /// </summary>
    public class PushCommand : IAppCommand<string, string>
    {
        /// <summary>
        /// The ExecuteAsync.
        /// </summary>
        /// <param name="input">The input<see cref="string"/>.</param>
        /// <returns>string.</returns>
        public Task<string> ExecuteAsync(string input)
        {
            throw new NotImplementedException();
        }
    }
}