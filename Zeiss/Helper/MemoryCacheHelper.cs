using Microsoft.Extensions.Caching.Memory;
using System;

namespace Zeiss.Helper
{
    public class MemoryCacheHelper : ICacheHelper
    {
        private readonly MemoryCache cache = new MemoryCache(new MemoryCacheOptions());
        public object GetCacheValue(string key)//获取值
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
        public void SetChacheValue(string key, object value)
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
