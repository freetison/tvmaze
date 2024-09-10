namespace TvMaze.HttpWorker.Commands
{
    using System.Threading.Tasks;

    using TvMaze.HttpServiceProvider;

    /// <summary>
    /// Defines the <see cref="PullCommand" />.
    /// </summary>
    public class PullCommand(IServiceScopeFactory scopeFactory) : AppCommand<string, ShowInfo?>
    {
        /// <summary>
        /// The ProcessAsync.
        /// </summary>
        /// <param name="input">The input<see cref="string"/>.</param>
        /// <returns>The task.</returns>
        public override async Task<ShowInfo?> ProcessAsync(string input)
        {
            using var scope = scopeFactory.CreateScope();
            var tvMazeApiClient = scope.ServiceProvider.GetRequiredService<ITvMazeApiClient>();
            var tvMazeData = await tvMazeApiClient.GetAllShows();
            return tvMazeData;
        }
    }
}