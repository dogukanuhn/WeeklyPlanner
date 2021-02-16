using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Application.Users.Queries
{
    public class AuthenticateUserQuery : IRequest<Response>
    {
        public string AccessCode { get; set; }
        public string Email { get; set; }

        public Guid AccessGuid { get; set; }



    }
}
