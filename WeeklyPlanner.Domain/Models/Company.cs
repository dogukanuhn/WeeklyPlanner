using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Domain.Models
{
    public class Company : BaseModel
    {
        public string Domain { get; set; }
        public string Type { get; set; }

    }
}
