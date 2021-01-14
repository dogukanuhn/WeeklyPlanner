using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyPlanner.Domain.Models;

namespace WeeklyPlanner.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }


    }
}
