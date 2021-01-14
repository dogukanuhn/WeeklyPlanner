using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Application.Common.Helpers
{
    public class JwtClaims
    {


        public static string Email { get; set; } = "Email";
        public static string UserId { get; set; } = "UserId";
        public static string Company { get; set; } = "Company";
    }
}
