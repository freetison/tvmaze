namespace TvMaze.HttpServiceProvider
{
    using System.Collections.Generic;
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
        /// The GetAllShows.
        /// </summary>
        /// <returns>The <see cref="IAsyncEnumerable{ShowInfo}"/>.</returns>
        public async Task<IEnumerable<ShowInfo>> GetAllShows()
        {
            var result = await _flurlCli
                .Request("shows")
                .GetJsonAsync<IEnumerable<ShowInfo>>();

            return result;
        }

        /// <summary>
        /// The GetShow.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>ShowInfo.</returns>
        async ValueTask<ShowInfo?> ITvMazeApiClient.GetShow(int id)
        {
            var result = await _flurlCli
                .Request($"shows/{id}")
                .GetJsonAsync<ShowInfo>();

            return result;
        }
    }
}