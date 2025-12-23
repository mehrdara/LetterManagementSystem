using Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;
namespace Infrastructure.Services
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public T Get<T>(string key) => _memoryCache.Get<T>(key);

        public void Set<T>(string key, T value, TimeSpan? expiration = null)
        {
            _memoryCache.Set(key, value, expiration ?? TimeSpan.FromMinutes(5));
        }

        public void Remove(string key) => _memoryCache.Remove(key);
    }
}