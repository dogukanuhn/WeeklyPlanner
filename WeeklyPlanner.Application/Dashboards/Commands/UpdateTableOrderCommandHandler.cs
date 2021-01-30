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
    public class UpdateTableOrderCommandHandler : IRequestHandler<UpdateTableOrderCommand, bool>
    {
        private readonly IDashboardRepository _dashboardRepository;

        public UpdateTableOrderCommandHandler(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        
        }
        public async Task<bool> Handle(UpdateTableOrderCommand request, CancellationToken cancellationToken)
        {
            var dashboard = await _dashboardRepository.GetAsync(x => x.CompanyName == request.Company);


            
            Table item = dashboard.Tables[request.OldIndex];
            dashboard.Tables.RemoveAt(request.OldIndex);
            dashboard.Tables.Insert(request.NewIndex, item);


         
            var result = await _dashboardRepository.UpdateAsync(dashboard, x => x.CompanyName == request.Company);

            if (result == null) return false;
            return true;

        }
    }
}
