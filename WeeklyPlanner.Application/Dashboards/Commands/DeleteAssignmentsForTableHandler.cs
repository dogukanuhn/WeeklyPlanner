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
    public class DeleteAssignmentsForTableHandler : IRequestHandler<DeleteAssignmentsForTableCommand, bool>
    {

        private readonly IDashboardRepository _dashboardRepository;
        public DeleteAssignmentsForTableHandler(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        public async Task<bool> Handle(DeleteAssignmentsForTableCommand request, CancellationToken cancellationToken)
        {
            var dashboard = await _dashboardRepository.GetAsync(x => x.Team == request.Team && x.Company.Domain == request.CompanyDomain);

            var table = dashboard.Tables.Find(x => x.TableName == request.Table);

            var assinnmentIndex = table.Assignments.FindIndex(x => x.Title == request.Title);
            table.Assignments.RemoveAt(assinnmentIndex);

            var result = await _dashboardRepository.UpdateAsync(dashboard, x => x.Team == request.Team && x.Company.Domain == request.CompanyDomain);

            if (result == null) return false;
            return true;

        }
    }
}
