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
    public class GetDashboardByCompanyHandler : IRequestHandler<GetDashboardByCompanyCommand, List<Dashboard>>
    {
        private IDashboardRepository _dashboardRepository;
    

        public GetDashboardByCompanyHandler(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
   
        }
        public async Task<List<Dashboard>> Handle(GetDashboardByCompanyCommand request, CancellationToken cancellationToken)
        {
     

            var dashboard = await _dashboardRepository.GetAllAsync(x => x.Company.Domain == request.CompanyDomain);

            return dashboard;

        }
    }
}
