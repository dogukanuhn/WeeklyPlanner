using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyPlanner.Application.Dashboards.Commands;

namespace WeeklyPlanner.Application.Validators
{
    public class CreateAssignmentCommandValidator : AbstractValidator<AddAssignmentToTableCommand>
    {
        public CreateAssignmentCommandValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().NotNull();
            RuleFor(x => x.TableName).NotEmpty().NotNull();
            RuleFor(x => x.Assignment).NotNull();

        }
    }
}
