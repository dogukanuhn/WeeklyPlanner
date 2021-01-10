using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Application.Common.Helpers
{
    public class ApplicationUser : IApplicationUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            Email = GetUserMail();
        }


        public string Email { get; set; }

        public string GetUserMail()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
        }


    }
}
