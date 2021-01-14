
using FluentValidation;
using WeeklyPlanner.Application.Users.Queries;

namespace WeeklyPlanner.Application.Validators.Users
{
    public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidator()
        {
            RuleFor(x => x.Email).NotEmpty();

        }
    }
}
