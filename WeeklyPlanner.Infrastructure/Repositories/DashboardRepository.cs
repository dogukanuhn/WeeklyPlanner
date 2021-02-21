using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeeklyPlanner.Application.Common.Interfaces;
using WeeklyPlanner.Domain.Models;
using WeeklyPlanner.Domain.Repositories;

namespace WeeklyPlanner.Infrastructure.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly IMongoDbContext<Dashboard> _context;
        private readonly IMongoCollection<Dashboard> _collection;
        public DashboardRepository(IMongoDbContext<Dashboard> context)
        {
            _context = context;
            _collection = _context.GetCollection();
        }

        public async Task<Dashboard> AddAsync(Dashboard entity, CancellationToken token)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await _collection.InsertOneAsync(entity, options, token);
            return entity;
        }

        public async Task<Dashboard> GetAsync(Expression<Func<Dashboard, bool>> predicate)
        {

            return await _collection.Find(predicate).FirstOrDefaultAsync();
        }
        public async Task<List<Dashboard>> GetAllAsync(Expression<Func<Dashboard, bool>> predicate)
        {

            return await _collection.Find(predicate).ToListAsync();
        }


        public  async Task<Dashboard> UpdateAsync(Dashboard entity, Expression<Func<Dashboard, bool>> predicate)
        {
            return await _collection.FindOneAndReplaceAsync(predicate, entity);
        }
    }
}
