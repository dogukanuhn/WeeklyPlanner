﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeeklyPlanner.Domain.Repositories;

namespace WeeklyPlanner.Application.Dashboards.Commands
{
    public class DeleteTableFromTableCommandHandler : IRequestHandler<DeleteTableFromTableCommand, bool>
    {
        private readonly IDashboardRepository _dashboardRepository;
        public DeleteTableFromTableCommandHandler(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        public async Task<bool> Handle(DeleteTableFromTableCommand request, CancellationToken cancellationToken)
        {
            var dashboard = await _dashboardRepository.GetAsync(x => x.Company.Domain == request.CompanyDomain && x.Team == request.Team);

            var table = dashboard.Tables.Find(x => x.TableName == request.TableName);

            dashboard.Tables.Remove(table);

            var result = await _dashboardRepository.UpdateAsync(dashboard, x => x.Company.Domain == request.CompanyDomain && x.Team == request.Team);

            if (result == null) return false;
            return true;
        }
    }
}
