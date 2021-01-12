﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyPlanner.Application.Models;
using WeeklyPlanner.Domain.Models;

namespace WeeklyPlanner.Application.Dashboards.Commands
{
    public class AddAssignmentToTableCommand : IRequest<Dashboard>
    {
        public string TableName { get; set; }
        public string CompanyName { get; set; }

        public AssignmentDTO Assignment { get; set; }

    }


}