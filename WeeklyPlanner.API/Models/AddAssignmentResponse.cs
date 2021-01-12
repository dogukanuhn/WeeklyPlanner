using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeeklyPlanner.Domain.Models;

namespace WeeklyPlanner.API.Models
{
    public class AddAssignmentResponse : BaseResponse
    {
        public Dashboard Dashboard { get; set; }
    }
}
