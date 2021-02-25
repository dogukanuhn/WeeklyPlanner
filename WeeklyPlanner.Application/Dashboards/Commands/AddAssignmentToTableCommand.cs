using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyPlanner.Application.Models;
using WeeklyPlanner.Domain.Models;

namespace WeeklyPlanner.Application.Dashboards.Commands
{
    public class AddAssignmentToTableCommand : IRequest<Dashboard>
    {
        public string TableName { get; set; }

        public string CompanyDomain { get; set; }

        public Assignment Assignment { get; set; }
        public string Team { get; set; }

        public int NewIndex { get; set; }


    }


}
