﻿using MediatR;
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
    public class CreateTableHandler : IRequestHandler<CreateTableCommand, Table>
    {
        private IDashboardRepository _dashboardRepository;
  

        public CreateTableHandler(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
       
        }
        public async Task<Table> Handle(CreateTableCommand request, CancellationToken cancellationToken)
        {
            var dashboard = await _dashboardRepository.GetAsync(x => x.CompanyName == request.Company);

            var newTable = new Table { TableName = request.TableName,Order = dashboard.Tables.Count };
            dashboard.Tables.Add(newTable);


            var result = await _dashboardRepository.UpdateAsync(dashboard, x => x.CompanyName == request.Company);

            return result != null ? newTable : null;


  
        }
    }
}