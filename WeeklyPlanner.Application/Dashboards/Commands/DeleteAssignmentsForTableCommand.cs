using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Application.Dashboards.Commands
{
    public class DeleteAssignmentsForTableCommand : IRequest<bool>
    {
        public string Table { get; set; }
        public string Title { get; set; }
        public string Team { get; set; }
        public string CompanyDomain { get; set; }



    }
}
