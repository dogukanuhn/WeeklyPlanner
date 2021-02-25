using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WeeklyPlanner.Application.Common.Helpers;
using WeeklyPlanner.Application.Common.Interfaces;
using WeeklyPlanner.Application.PipelineBehaviours;
using WeeklyPlanner.Application.Services;
using WeeklyPlanner.Domain.Common;

namespace WeeklyPlanner.Application
{
    public static class DI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IJwtHandler, JwtHandler>();



            services.AddSingleton<IEmailService, EmailService>();

          

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));





            return services;
        }
    }
}
