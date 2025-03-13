namespace TvMaze.HttpServiceProvider
{
    using TvMaze.ShareCommon.Models.TvMaze;

    /// <summary>
    /// Defines the <see cref="ITvMazeApiClient" />.
    /// </summary>
    public interface ITvMazeApiClient
    {
        /// <summary>
        /// The GetAllShows.
        /// </summary>
        /// <returns>The <see cref="Task{Show}"/>.</returns>
        Task<IEnumerable<ShowInfo>> GetAllShows();

        /// <summary>
        /// The GetShow.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{Show}"/>.</returns>
        ValueTask<ShowInfo?> GetShow(int id);
    }
}