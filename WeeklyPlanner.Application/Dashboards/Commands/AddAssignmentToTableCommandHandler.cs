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

namespace WeeklyPlanner.Application.Dashboards.Commands
{
    public class AddAssignmentToTableCommandHandler : IRequestHandler<AddAssignmentToTableCommand, Dashboard>
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly IApplicationUser _applicationUser;
        public AddAssignmentToTableCommandHandler(IDashboardRepository dashboardRepository, IApplicationUser applicationUser)
        {
            _dashboardRepository = dashboardRepository;
            _applicationUser = applicationUser;
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
                EndDate = request.Assignment.EndDate,
                Order = request.Assignment.Order,
                ModifiedBy = _applicationUser.UserId
            };

            var dashboard = await _dashboardRepository.GetAsync(x => x.CompanyName == _applicationUser.Company);

            Table table = dashboard.Tables.Single(x => x.TableName == request.TableName);
            Assignment data = table.Assignments.SingleOrDefault(x => x.Order == requstData.Order);

            if (data != null) {

                foreach (var item in table.Assignments)
                {
                    if (item.Order <= request.Assignment.Order && item.Order != 0)
                        item.Order--;
                    
                    if (item.Order >= request.Assignment.Order)
                        item.Order++;
                    
                }
                
            }
            table.Assignments.Remove(data);
            table.Assignments.Add(requstData);
            

            table.Assignments.OrderBy(x => x.Order);

            var result = await _dashboardRepository.UpdateAsync(dashboard, x => x.CompanyName == _applicationUser.Company);

            return dashboard;
        }
    }
}
