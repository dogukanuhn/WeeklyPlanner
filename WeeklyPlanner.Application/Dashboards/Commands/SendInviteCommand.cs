using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Application.Dashboards.Commands
{
    public class SendInviteCommand : IRequest<bool>
    {
        public List<string> UserMailList { get; set; }

    }
}
