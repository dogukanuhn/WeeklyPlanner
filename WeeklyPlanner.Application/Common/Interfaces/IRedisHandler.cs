using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Application.Common.Interfaces
{
    public interface IRedisHandler
    {
        Task<string> GetFromCache(string key);
        Task<bool> AddToCache(string key, TimeSpan timeout, string data);
    }
}
