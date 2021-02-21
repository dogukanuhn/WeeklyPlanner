using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeeklyPlanner.Domain.Common;
using WeeklyPlanner.Domain.Models;
using WeeklyPlanner.Domain.Repositories;

namespace WeeklyPlanner.Application.Dashboards.Commands
{
    public class CreateDashboardCommandHandler : IRequestHandler<CreateDashboardCommand, Dashboard>
    {
        private readonly IDashboardRepository _dashboardRepository;
      

        public CreateDashboardCommandHandler(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
           
        }
        public async Task<Dashboard> Handle(CreateDashboardCommand request, CancellationToken cancellationToken)
        {
            
            var createdDashboard = new Dashboard(request.Team, request.Company, request.Tables);

            var result = await _dashboardRepository.AddAsync(createdDashboard, cancellationToken);

            return result; 
            
        }
    }
}
