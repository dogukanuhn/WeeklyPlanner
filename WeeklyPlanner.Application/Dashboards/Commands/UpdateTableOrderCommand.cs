using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Application.Dashboards.Commands
{
    public class UpdateTableOrderCommand : IRequest<bool>
    {
        public string TableName { get; set; }
        public string Company { get; set; }
        public int OldIndex { get; set; }
        public int NewIndex { get; set; }


    }
}
