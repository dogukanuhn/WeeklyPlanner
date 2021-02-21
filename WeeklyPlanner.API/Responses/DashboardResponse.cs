using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeeklyPlanner.Domain.Models;

namespace WeeklyPlanner.API.Responses
{
    public class DashboardResponse : BaseResponse
    {
        public List<Dashboard> Boards { get; set; }
    }
}
