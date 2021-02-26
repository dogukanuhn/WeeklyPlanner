using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Application.Dashboards.Commands
{
    public class DeleteTableFromTableCommand : IRequest<bool>
    {
        public string TableName { get; set; }
        public string Team { get; set; }
        public string CompanyDomain { get; set; }


    }
}
