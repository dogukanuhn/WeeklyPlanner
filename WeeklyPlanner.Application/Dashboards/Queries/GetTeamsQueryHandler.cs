using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeeklyPlanner.Domain.Common;
using WeeklyPlanner.Domain.Models;
using WeeklyPlanner.Domain.Repositories;

namespace WeeklyPlanner.Application.Dashboards.Queries
{
    public class GetTeamsQueryHandler : IRequestHandler<GetTeamsQuery, List<string>>
    {
        private IDashboardRepository _dashboardRepository;
    

        public GetTeamsQueryHandler(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
   
        }
        public async Task<List<string>> Handle(GetTeamsQuery request, CancellationToken cancellationToken)
        {
     

            var dashboard = await _dashboardRepository.GetAllAsync(x => x.Company.Domain == request.CompanyDomain);

            List<string> teams = new List<string>();

            foreach (var item in dashboard)
            {
                teams.Add(item.Team);
            }

            return teams;

        }
    }
}
