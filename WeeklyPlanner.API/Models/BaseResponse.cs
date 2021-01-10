using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeeklyPlanner.API.Models
{
    public class BaseResponse
    {

        public bool HasError { get; set; }
        public string Error { get; set; }

    }
}
