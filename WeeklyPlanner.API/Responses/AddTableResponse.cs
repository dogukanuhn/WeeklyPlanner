using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeeklyPlanner.API.Responses;
using WeeklyPlanner.Domain.Models;

namespace WeeklyPlanner.API.Responses
{
    public class AddTableResponse : BaseResponse
    {
        public Table Table { get; set; }
    }
}
