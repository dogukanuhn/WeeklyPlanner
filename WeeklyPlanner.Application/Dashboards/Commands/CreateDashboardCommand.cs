using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyPlanner.Domain.Models;

namespace WeeklyPlanner.Application.Dashboards.Commands
{
    public class CreateDashboardCommand : IRequest<Dashboard>
    {
        public string CompanyName { get; set; }
        public List<string> Tables { get; set; }
    }
}
