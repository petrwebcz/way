using Microsoft.Extensions.Caching.Memory;
using System;

namespace WhereAreYou.MobileApp.Services
{
    public class CacheProviderService : ICacheProviderService
    {
        private readonly IMemoryCache _cache;

        public CacheProviderService()
        {
            _cache = new MemoryCache(new MemoryCacheOptions() { });
        }

        public void Set<T>(string key, T value)
        {
            _cache.Set(key, value, DateTime.MaxValue); //TODO: Move to constants.
        }

        public T Get<T>(string key)
        {
            if (_cache.TryGetValue(key, out T value))
                return value;
            else
                return default(T);
        }
    }
}
