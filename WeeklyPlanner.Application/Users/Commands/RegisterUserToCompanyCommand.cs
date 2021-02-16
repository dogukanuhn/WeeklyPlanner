using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Application.Users.Commands
{
    public class RegisterUserToCompanyCommand : IRequest<bool>
    {
        public Guid SecurityGuid { get; set; }
        public string Email { get; set; }


    }
}
