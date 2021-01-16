using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeeklyPlanner.Domain.Common;
using WeeklyPlanner.Domain.Repositories;

namespace WeeklyPlanner.Application.Dashboards.Commands
{
    public class UpdateTableOrderCommandHandler : IRequestHandler<UpdateTableOrderCommand, bool>
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly IApplicationUser _applicationUser;



        public UpdateTableOrderCommandHandler(IDashboardRepository dashboardRepository, IApplicationUser applicationUser)
        {
            _dashboardRepository = dashboardRepository;
            _applicationUser = applicationUser;
        }
        public async Task<bool> Handle(UpdateTableOrderCommand request, CancellationToken cancellationToken)
        {
            var dashboard = await _dashboardRepository.GetAsync(x => x.CompanyName == _applicationUser.Company);
           

            foreach (var item in dashboard.Tables)
            {
                if (item.Order >= request.Order) item.Order++;
                if (item.Order < request.Order && item.Order != 0) item.Order--;

            }

            var result = await _dashboardRepository.UpdateAsync(dashboard, x => x.CompanyName == _applicationUser.Company);

            if (result == null) return false;
            return true;

        }
    }
}
