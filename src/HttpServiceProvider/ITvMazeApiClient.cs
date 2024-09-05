namespace TvMaze.HttpServiceProvider
{
    using TvMaze.ShareCommon.Models.TvMaze;

    /// <summary>
    /// Defines the <see cref="ITvMazeApiClient" />.
    /// </summary>
    public interface ITvMazeApiClient
    {
        /// <summary>
        /// The GetShows.
        /// </summary>
        /// <returns>The <see cref="Task{Show}"/>.</returns>
        Task<Show> GetShows();

        /// <summary>
        /// The GetShow.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{Show}"/>.</returns>
        Task<Show> GetShow(int id);
    }
}