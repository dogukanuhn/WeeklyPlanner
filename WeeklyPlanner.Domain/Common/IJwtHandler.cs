using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyPlanner.Domain.Models;

namespace WeeklyPlanner.Domain.Common
{
    public interface IJwtHandler
    {
        (string email, string token)? Authenticate(User user);
    }
}
