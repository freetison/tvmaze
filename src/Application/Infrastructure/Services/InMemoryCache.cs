namespace TvMaze.Application.Infrastructure.Services
{
    using Microsoft.Extensions.Caching.Memory;

    /// <summary>
    /// Defines the <see cref="InMemoryCache" />.
    /// </summary>
    public class InMemoryCache
    {
        /// <summary>
        /// Defines the _cache.
        /// </summary>
        private readonly IMemoryCache _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryCache"/> class.
        /// </summary>
        /// <param name="cache">The cache<see cref="IMemoryCache"/>.</param>
        public InMemoryCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        // Método genérico para establecer valores en caché

        /// <summary>
        /// The SetValue.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="key">The key<see cref="string"/>.</param>
        /// <param name="value">The value of T.</param>
        /// <param name="absoluteExpirationRelativeToNow">The absoluteExpirationRelativeToNow.</param>
        /// <param name="slidingExpiration">The slidingExpiration.</param>
        public void SetValue<T>(string key, T value, TimeSpan? absoluteExpirationRelativeToNow = null, TimeSpan? slidingExpiration = null)
        {
            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow ?? TimeSpan.FromMinutes(5),
                SlidingExpiration = slidingExpiration ?? TimeSpan.FromMinutes(2),
            };

            _cache.Set(key, value, cacheOptions);
        }

        // Método genérico para obtener valores del caché

        /// <summary>
        /// The GetValue.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="key">The key<see cref="string"/>.</param>
        /// <returns>T>.</returns>
        public T? GetValue<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        // Método para eliminar un valor del caché

        /// <summary>
        /// The Remove.
        /// </summary>
        /// <param name="key">The key<see cref="string"/>.</param>
        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}