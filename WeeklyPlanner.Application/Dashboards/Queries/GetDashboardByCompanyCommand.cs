﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyPlanner.Domain.Models;

namespace WeeklyPlanner.Application.Dashboards.Queries
{
    public class GetDashboardByCompanyCommand : IRequest<Dashboard>
    {
        public string Company { get; set; }
    }
}