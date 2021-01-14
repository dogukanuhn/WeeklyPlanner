using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyPlanner.Application.Common.Helpers;
using WeeklyPlanner.Application.Users.Queries;

namespace WeeklyPlanner.Application.Validators.Users
{
    public class AuthenticateUserQueryValidator : AbstractValidator<AuthenticateUserQuery>
    {
        public AuthenticateUserQueryValidator()
        {
            RuleFor(x => x.Email).NotEmpty().Must(EmailVerify.EmailIsValid);
            RuleFor(x => x.AccessGuid).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(x => x.AccessCode).NotEmpty().Length(6);

        }
    }
}
