using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WeeklyPlanner.Domain.Common;

namespace WeeklyPlanner.Application.Common.Helpers
{
    public class ApplicationUser : IApplicationUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            Email = GetUserMail();
            Company = GetUserCompany();
            UserId = GetUserId();

        }


        public string Email { get; set; }
        public string Company { get; set; }
        public string UserId { get; set; }

        public string GetUserMail()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(JwtClaims.Email.ToString()).Value;
        }

        public string GetUserCompany()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(JwtClaims.Company.ToString()).Value;
        }

        public string GetUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(JwtClaims.UserId.ToString()).Value;
        }


    }
}
