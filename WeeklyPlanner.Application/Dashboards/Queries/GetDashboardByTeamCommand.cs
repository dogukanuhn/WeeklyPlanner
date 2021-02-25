using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyPlanner.Domain.Models;

namespace WeeklyPlanner.Application.Dashboards.Queries
{
    public class GetDashboardByTeamCommand : IRequest<Dashboard>
    {
        public string CompanyDomain { get; set; }
        public string Team { get; set; }

    }
}
