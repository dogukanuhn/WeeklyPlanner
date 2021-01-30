using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeeklyPlanner.API.Responses
{
    public class LoginResponseModel : BaseResponse
    {
        public Guid AccessGuid { get; set; }
    }
}
