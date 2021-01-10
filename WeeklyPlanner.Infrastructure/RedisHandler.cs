using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyPlanner.Application.Common.Interfaces;

namespace WeeklyPlanner.Infrastructure
{
    public class RedisHandler : IRedisHandler
    {
        private readonly IDistributedCache _distributedCache;

        public RedisHandler(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;

        }


        public async Task<string> GetFromCache(string key)
        {
            var isCached = await IsCached(key);
            if (!isCached)
            {
                return null;
            }

            var cachedData = await _distributedCache.GetStringAsync(key);
            return await Task.FromResult(cachedData);

        }

        public async Task<bool> AddToCache(string key, TimeSpan timeout, string data)
        {
            bool isCached = await IsCached(key);
            if (isCached)
            {
                return await Task.FromResult(false);
            }

            await _distributedCache.SetStringAsync(key, data, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = timeout
            });
            return await Task.FromResult(true);
        }


        private async Task<bool> IsCached(string key)
        {
            var cachedData = await _distributedCache.GetStringAsync(key);

            return string.IsNullOrEmpty(cachedData) ? await Task.FromResult(false) : await Task.FromResult(true);
        }
    }
}
