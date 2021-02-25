using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeeklyPlanner.Domain.Models;

namespace WeeklyPlanner.API.Responses
{
    public class TeamResponse : BaseResponse
    {
        public List<string> Teams { get; set; }
    }
}
