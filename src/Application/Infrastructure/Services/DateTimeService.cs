namespace TvMaze.Application.Infrastructure.Services
{
    using TvMaze.Application.Common.Interfaces;

    /// <summary>
    /// Defines the <see cref="DateTimeService" />.
    /// </summary>
    public class DateTimeService : IDateTime
    {
        /// <summary>
        /// Gets the Now.
        /// </summary>
        public DateTime Now => DateTime.Now;
    }
}