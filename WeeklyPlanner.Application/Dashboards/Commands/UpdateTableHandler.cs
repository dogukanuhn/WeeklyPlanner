using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeeklyPlanner.Domain.Repositories;

namespace WeeklyPlanner.Application.Dashboards.Commands
{
    public class UpdateTableHandler : IRequestHandler<UpdateTableCommand, bool>
    {
        public readonly IDashboardRepository _dashboardRepository;
        public UpdateTableHandler(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        public async Task<bool> Handle(UpdateTableCommand request, CancellationToken cancellationToken)
        {
            
            var dashboard = await _dashboardRepository.GetAsync(x => x.Company.Domain == request.CompanyDomain && x.Team == request.Team);


            foreach (var item in dashboard.Tables.Select((value, i) => new { i, value }).ToList())
            {
                foreach (var table in request.Tables.ToList())
                {
                    if (table.TableName.Contains(item.value.TableName))
                    {
                        dashboard.Tables[item.i] = table;
                    }
                }
            }

            var result = await _dashboardRepository.UpdateAsync(dashboard, x => x.Company.Domain == request.CompanyDomain && x.Team == request.Team);

            if (result == null) return false;
            return true;
         }
    }
}
