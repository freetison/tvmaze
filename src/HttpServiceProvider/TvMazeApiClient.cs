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
        /// The GetAllShows.
        /// </summary>
        /// <returns>The <see cref="Task{Show}"/>.</returns>
        public async Task<ShowInfo?> GetAllShows()
        {
            try
            {
                var result = await _flurlCli
                .Request("shows/1")
                .GetJsonAsync<ShowInfo>();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// The GetShow.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{Show}"/>.</returns>
        public async Task<ShowInfo?> GetShow(int id)
        {
            return await _flurlCli
                .Request($"shows/{id}")
                .GetJsonAsync<ShowInfo>();
        }
    }
}