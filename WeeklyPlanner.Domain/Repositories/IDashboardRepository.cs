using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeeklyPlanner.Domain.Models;

namespace WeeklyPlanner.Domain.Repositories
{
    public interface IDashboardRepository
    {
        Task<Dashboard> GetAsync(Expression<Func<Dashboard, bool>> predicate);
        Task<Dashboard> AddAsync(Dashboard entity, CancellationToken token);
        Task<Dashboard> UpdateAsync(Dashboard entity, Expression<Func<Dashboard, bool>> predicate);
    }
}
