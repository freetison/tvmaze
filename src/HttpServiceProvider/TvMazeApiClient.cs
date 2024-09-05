namespace TvMaze.HttpServiceProvider
{
    using Flurl.Http;
    using Flurl.Http.Configuration;
    using TvMaze.ShareCommon.Models.TvMaze;

    /// <summary>
    /// Defines the <see cref="TvMazeApiClient" />.
    /// </summary>
    public class TvMazeApiClient(IFlurlClientCache clients) : ITvMazeApiClient
    {
        /// <summary>
        /// Defines the _flurlCli.
        /// </summary>
        private readonly IFlurlClient _flurlCli = clients.Get("TvMazeApi");

        /// <summary>
        /// The GetShows.
        /// </summary>
        /// <returns>The <see cref="Task{Show}"/>.</returns>
        public async Task<Show> GetShows()
        {
            return await _flurlCli
                .Request("shows")
                .GetJsonAsync<Show>();
        }

        /// <summary>
        /// The GetShow.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{Show}"/>.</returns>
        public async Task<Show> GetShow(int id)
        {
            return await _flurlCli
                .Request($"shows/{id}")
                .GetJsonAsync<Show>();
        }
    }
}