using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeeklyPlanner.API.Responses;
using WeeklyPlanner.Application.Common.Helpers;
using WeeklyPlanner.Application.Dashboards.Commands;
using WeeklyPlanner.Application.Dashboards.Queries;
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



        /// <summary>
        /// Get all teams for Company
        /// </summary>
        /// <response code="200">Gives all teams</response>
        /// <response code="404">Teams not found</response>    
        /// <response code="401">Unauthorized</response>          
        /// 
        [HttpGet("teams")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeamResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound,Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetTeams()
        {
            try
            {
                var command = new GetTeamsCommand();
                command.CompanyDomain = HttpContext.User.FindFirst(JwtClaims.CompanyDomain.ToString()).Value;

                var result = await _mediator.Send(command);

                if (result == null)
                {
                    return NotFound(new ErrorResponse
                    {
                        HasError = true,
                        Error = "Dasboard Not Found"
                    });
                }

                return Ok(new TeamResponse
                {
                    HasError = false,
                    Teams = result
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get all dashboard by for a certain team
        /// </summary>
        /// <response code="200">Gives a dashboard for selected team</response>
        /// <response code="404">If dashboard not found for selected team</response>          
        /// <response code="401">Unauthorized</response>          
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DashboardResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] string team)
        {
            try
            {
                var command = new GetDashboardByTeamCommand();
                command.CompanyDomain = HttpContext.User.FindFirst(JwtClaims.CompanyDomain.ToString()).Value;
                command.Team = team;
                var result = await _mediator.Send(command);

                if (result == null)
                {
                    return BadRequest(new ErrorResponse
                    {
                        HasError = true,
                        Error = "Dasboard Not Found"
                    });
                }

                return Ok(new DashboardResponse
                {
                    HasError = false,
                    Dashboard =  result
                });
            }
            catch (Exception)
            {

                throw;
            }
        }



        /// <summary>
        /// Get team name and create dashboard
        /// </summary>
        /// <response code="200">Created successfully</response>
        /// <response code="404">Error while creating dashboard</response>          
        /// <response code="401">Unauthorized</response>          
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Dashboard))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<IActionResult> CreateDashboard([FromBody] CreateDashboardCommand command)
        {
            try
            {
                command.Company.Domain = HttpContext.User.FindFirst(JwtClaims.CompanyDomain.ToString()).Value;

                var result = await _mediator.Send(command);
                if (result == null)
                {
                    return BadRequest(new ErrorResponse { 
                    HasError=true,
                    Error="Create Dashboard Failed"
                    });
                }
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Create table for team
        /// </summary>
        /// <response code="200">Created successfully</response>
        /// <response code="404">Error while creating table</response>          
        /// <response code="401">Unauthorized</response>         
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddTableResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost("CreateTable")]
        public async Task<IActionResult> CreateTable([FromBody] CreateTableCommand command)
        {
            try
            {
                command.CompanyDomain = HttpContext.User.FindFirst(JwtClaims.CompanyDomain.ToString()).Value;

                var result = await _mediator.Send(command);
                if (result == null)
                {
                    return BadRequest(new ErrorResponse
                    {
                        HasError = true,
                        Error = "Table cannot created"
                    });
                }

                return Ok(new AddTableResponse
                {
                    HasError = false,
                    Table = result
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Update Table Order
        /// </summary>
        /// <response code="200">Created successfully</response>
        /// <response code="404">Error while updating table</response>          
        /// <response code="401">Unauthorized</response>         
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("UpdateTableOrder")]
        public async Task<IActionResult> UpdateTableOrder([FromBody] UpdateTableOrderCommand command)
        {
            try
            {
                command.CompanyDomain = HttpContext.User.FindFirst(JwtClaims.CompanyDomain.ToString()).Value;
                var result = await _mediator.Send(command);

                if (!result)
                {
                    return BadRequest(new ErrorResponse
                    {
                        HasError = true,
                        Error = "Fail to update table order"
                    });
                }
                return Ok(new BaseResponse
                {
                    HasError = false

                });

            }
            catch (Exception)
            {

                throw;
            }
        }

        //[HttpPost("SendInvite")]
        //public async Task<IActionResult> SendInvite([FromBody] SendInviteCommand command)
        //{
        //    try
        //    {
        //        var result = await _mediator.Send(command);

        //        if (!result)
        //        {
        //            return BadRequest(new ErrorResponse
        //            {
        //                HasError = true,
        //                Error = "Error while sending messages to users"
        //            });
        //        }
        //        return Ok(new BaseResponse
        //        {
        //            HasError = false,

        //        });

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        /// <summary>
        /// Update Tables when assignment position changed
        /// </summary>
        /// <response code="200">Updated successfully</response>
        /// <response code="404">Error while changing position</response>          
        /// <response code="401">Unauthorized</response>         
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost("UpdateTables")]
        public async Task<IActionResult> UpdateTables(UpdateTableCommand command)
        {
            command.CompanyDomain = HttpContext.User.FindFirst(JwtClaims.CompanyDomain.ToString()).Value;

            try
            {
                var result = await _mediator.Send(command);
                if(!result)
                {
                    return BadRequest(new ErrorResponse
                    {
                        HasError = true,
                        Error = "Update Failure"
                    });
                }

                return Ok(new BaseResponse
                {
                    HasError = false
                });
            }
            catch (Exception)
            {

                throw;
            }
        }



        /// <summary>
        /// Add assignment for certain tablle
        /// </summary>
        /// <response code="200">Added successfully</response>
        /// <response code="404">Error while creating assignment</response>          
        /// <response code="401">Unauthorized</response>         
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddAssignmentResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost("AddAssignment")]
        public async Task<IActionResult> AddAssignment(AddAssignmentToTableCommand command)
        {

            command.CompanyDomain = HttpContext.User.FindFirst(JwtClaims.CompanyDomain.ToString()).Value;
            try
            {
                var result = await _mediator.Send(command);
                if (result == null)
                {
                    return BadRequest(new ErrorResponse
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
