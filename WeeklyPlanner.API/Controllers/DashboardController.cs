using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeeklyPlanner.API.Models;
using WeeklyPlanner.Application.Dashboards.Commands;
using WeeklyPlanner.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeeklyPlanner.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

       

        //// GET api/<DashboardController>/5
        //[HttpGet("{id}")]
        //public async Task<DashboardTableDTO> Get()
        //{
        //    return "value";
        //}

        // POST api/<DashboardController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDashboardCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result == null)
                {
                    return BadRequest(new DashboardResponse { 
                    HasError=true,
                    Error="Create Dashboard Failed"
                    });
                }
                return Ok(new DashboardResponse
                {
                    HasError = false,

                    Tables = result.Tables
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [AllowAnonymous]
        [HttpPost("AddAssignment")]
        public async Task<IActionResult> AddAssignment(AddAssignmentToTableCommand command)
        {

            try
            {
                var result = await _mediator.Send(command);
                if (result == null)
                {
                    return BadRequest(new AddAssignmentResponse
                    {
                        HasError = true,
                        Error = "Add Assignment to Dashboard Failed"
                    });
                }
                return Ok(new AddAssignmentResponse
                {
                    HasError = false,
                    Dashboard = result
                   
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}
