using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyPlanner.Domain.Models;

namespace WeeklyPlanner.Application.Dashboards.Commands
{
    public class CreateTableCommand : IRequest<Table>
    {
        public string TableName { get; set; }
        public string Team { get; set; }

        public string CompanyDomain { get; set; }
    }
}
