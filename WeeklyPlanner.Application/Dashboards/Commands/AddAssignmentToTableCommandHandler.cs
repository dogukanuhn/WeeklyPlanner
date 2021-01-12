using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeeklyPlanner.Domain.Models;
using WeeklyPlanner.Domain.Repositories;

namespace WeeklyPlanner.Application.Dashboards.Commands
{
    public class AddAssignmentToTableCommandHandler : IRequestHandler<AddAssignmentToTableCommand, Dashboard>
    {
        private readonly IDashboardRepository _dashboardRepository;
        public AddAssignmentToTableCommandHandler(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        public async Task<Dashboard> Handle(AddAssignmentToTableCommand request, CancellationToken cancellationToken)
        {
            var requstData = new Assignment
            {
                Content = request.Assignment.Content,
                IsCompleted = request.Assignment.IsCompleted,
                Title = request.Assignment.Title,
                Notify = request.Assignment.Notify,
                Priority = request.Assignment.Priority,
                ModifiedBy = request.Assignment.ModifiedBy,
                EndDate = request.Assignment.EndDate,
                Order = request.Assignment.Order
            };

            var dashboard = await _dashboardRepository.GetAsync(x => x.CompanyName == request.CompanyName);

            Table table = dashboard.Tables.Single(x => x.TableName == request.TableName);
            Assignment data = table.Assignments.SingleOrDefault(x => x.Order == requstData.Order);

            if (data != null) {
                data.Order++;
            }
            table.Assignments.Add(requstData);

            table.Assignments.OrderBy(x => x.Order);

            var result = await _dashboardRepository.UpdateAsync(dashboard, x => x.CompanyName == request.CompanyName);

            return dashboard;
        }
    }
}
