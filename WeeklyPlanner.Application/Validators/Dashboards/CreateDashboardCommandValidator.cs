using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyPlanner.Application.Dashboards.Commands;

namespace WeeklyPlanner.Application.Validators.Dashboards
{
    public class CreateDashboardCommandValidator : AbstractValidator<CreateDashboardCommand>
    {
        public CreateDashboardCommandValidator()
        {
            RuleFor(x => x.CompanyName).NotNull().NotEmpty();
            RuleFor(x => x.Tables).NotNull();
        }
    }
}
