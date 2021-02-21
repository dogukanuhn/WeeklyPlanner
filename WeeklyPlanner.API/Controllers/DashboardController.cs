using MediatR;
using Microsoft.AspNetCore.Authorization;
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



        // GET api/<DashboardController>/5
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var command = new GetDashboardByCompanyCommand();
                command.CompanyDomain = HttpContext.User.FindFirst(JwtClaims.CompanyDomain.ToString()).Value;

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
                    Boards = result
                });
            }
            catch (Exception)
            {

                throw;
            }
        }



        // POST api/<DashboardController>
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

            
        [HttpPost("createTable")]
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
                return Ok(new AddAssignmentResponse
                {
                    HasError = false,
        

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

        [HttpPost("AddAssignment")]
        public async Task<IActionResult> AddAssignment(AddAssignmentToTableCommand command)
        {

            command.UserId = HttpContext.User.FindFirst(JwtClaims.UserId.ToString()).Value;
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
