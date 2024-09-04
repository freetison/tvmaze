namespace TvMaze.Application.Common.Mappings
{
    using TvMaze.Application.Common.Models;

    /// <summary>
    /// Defines the <see cref="MappingExtensions" />.
    /// </summary>
    public static class MappingExtensions
    {
        /// <summary>
        /// The PaginatedListAsync.
        /// </summary>
        /// <typeparam name="TDestination">.</typeparam>
        /// <param name="queryable">The queryable<see cref="IQueryable{TDestination}"/>.</param>
        /// <param name="pageNumber">The pageNumber<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <returns>The Task{PaginatedList{TDestination}}"/>.</returns>
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
        {
            return PaginatedList<TDestination>.CreateAsync(queryable, pageNumber, pageSize);
        }
    }
}