using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Application.Users.Queries
{
    public class LoginUserQuery : IRequest<Guid>
    {
        public string Email { get; set; }

    }
}
