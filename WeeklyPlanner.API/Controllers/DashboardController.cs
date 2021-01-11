using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeeklyPlanner.API.Models;
using WeeklyPlanner.Application.Dashboards.Commands;

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

        // GET: api/<DashboardController>
        [HttpGet]
        public async Task<IEnumerable<string>> Get([FromBody] GetCompanyTablesDTO dto )
        {
            try
            {
                //var tables = await _mediator.Send()
            }
            catch (Exception)
            {

                throw;
            }
            return new string[] { "value1", "value2" };
        }

        // GET api/<DashboardController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

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

        // PUT api/<DashboardController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DashboardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
