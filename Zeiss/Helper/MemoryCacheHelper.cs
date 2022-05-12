using Microsoft.Extensions.Caching.Memory;
using System;

namespace Zeiss.Helper
{
    public static class MemoryCacheHelper
    {
        private static readonly MemoryCache cache = new MemoryCache(new MemoryCacheOptions());
        public static object GetCacheValue(string key)//获取值
        {
            if (key != null && cache.TryGetValue(key, out object val))
            {
                return val;
            }
            else
            {
                return default;
            }
        }
        public static void SetChacheValue(string key, object value)
        {
            if (key != null)
            {
                cache.Set(key, value, new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromSeconds(3600)
                });
            }
        }
    }
}
