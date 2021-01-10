using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Application.Common.Interfaces
{
    public interface IMongoDbContext<T>
    {
        IMongoCollection<T> GetCollection();
    }
}
