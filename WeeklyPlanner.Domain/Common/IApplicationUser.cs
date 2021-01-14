using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Domain.Common
{
    public interface IApplicationUser
    {
        public string Email { get; set; }
        public string Company { get; set; }
        public string UserId { get; set; }



    }
}
