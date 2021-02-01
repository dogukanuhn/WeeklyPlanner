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
    
        public AddAssignmentToTableCommandHandler(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
         
        }
        public async Task<Dashboard> Handle(AddAssignmentToTableCommand request, CancellationToken cancellationToken)
        {

            var dashboard = await _dashboardRepository.GetAsync(x => x.CompanyName == request.Company);

            Table table = dashboard.Tables.Single(x => x.TableName == request.TableName);
            int oldIndex = table.Assignments.FindIndex(x=> x.Title == request.Assignment.Title);

            if (oldIndex != -1)
            {

                Assignment item = table.Assignments[oldIndex];
                table.Assignments.RemoveAt(oldIndex);
                table.Assignments.Insert(request.NewIndex, item);


            }
            else
            {
                table.Assignments.Remove(request.Assignment);
                table.Assignments.Add(request.Assignment);
            }




            var result = await _dashboardRepository.UpdateAsync(dashboard, x => x.CompanyName == request.Company);

            return result;
        }
    }
}
