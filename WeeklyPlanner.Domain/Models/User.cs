using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Domain.Models
{
    public class User : BaseModel
    {

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
    

    }
}
