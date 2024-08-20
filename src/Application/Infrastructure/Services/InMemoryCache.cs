using Microsoft.Extensions.Caching.Memory;

namespace TvMaze.Application.Infrastructure.Services;

public class InMemoryCache
{
    private readonly IMemoryCache _cache;

    public InMemoryCache(IMemoryCache cache)
    {
        _cache = cache;
    }

    // Método genérico para establecer valores en caché
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
    public T? GetValue<T>(string key)
    {
        return _cache.Get<T>(key);
    }

    // Método para eliminar un valor del caché
    public void Remove(string key)
    {
        _cache.Remove(key);
    }
}
