using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeeklyPlanner.API.Models
{
    public class AuthenticateResponse : BaseResponse
    {
        public string Token { get; set; }

    }
}
