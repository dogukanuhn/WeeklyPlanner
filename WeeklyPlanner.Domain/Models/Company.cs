using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Domain.Models
{
    public class Company : BaseModel
    {
        public string Name { get; set; }
        public string Domain { get; set; }


    }
}
