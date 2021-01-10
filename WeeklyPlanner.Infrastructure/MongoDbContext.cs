using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyPlanner.Application.Common.Interfaces;

namespace WeeklyPlanner.Infrastructure
{
    public class MongoDbContext<T> : IMongoDbContext<T>
    {
        protected readonly IMongoCollection<T> Collection;
        private readonly MongoDbSettings settings;
        private IMongoDatabase Db { get; set; }
        public MongoDbContext(IOptions<MongoDbSettings> options)
        {
            this.settings = options.Value;
            var client = new MongoClient(this.settings.ConnectionString);
            Db = client.GetDatabase(this.settings.Database);
        }



        public IMongoCollection<T> GetCollection()
        {
            return Db.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
        }
    }
}
