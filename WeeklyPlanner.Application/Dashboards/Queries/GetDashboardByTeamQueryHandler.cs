﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeeklyPlanner.Domain.Models;
using WeeklyPlanner.Domain.Repositories;

namespace WeeklyPlanner.Application.Dashboards.Queries
{
    public class GetDashboardByTeamQueryHandler : IRequestHandler<GetDashboardByTeamQuery, Dashboard>
    {
        private readonly IDashboardRepository _dashboardRepository;
        public GetDashboardByTeamQueryHandler(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        public async Task<Dashboard> Handle(GetDashboardByTeamQuery request, CancellationToken cancellationToken)
        {

            var dashboard = await _dashboardRepository.GetAsync(x => x.Company.Domain == request.CompanyDomain && x.Team == request.Team);

         

            return dashboard;
        }
    }
}
