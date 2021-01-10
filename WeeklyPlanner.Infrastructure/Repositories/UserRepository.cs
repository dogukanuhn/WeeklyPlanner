using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IMongoDbContext<User> _context;
        private readonly IMongoCollection<User> _collection;
        public UserRepository(IMongoDbContext<User> context)
        {
            _context = context;
            _collection = _context.GetCollection();
        }

        public async Task<User> AddAsync(User entity, CancellationToken token)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await _collection.InsertOneAsync(entity, options, token);
            return entity;
        }

        
    }
}
