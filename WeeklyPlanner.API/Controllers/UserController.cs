using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeeklyPlanner.API.Responses;
using WeeklyPlanner.Application.Users.Commands;
using WeeklyPlanner.Application.Users.Queries;

namespace WeeklyPlanner.API.Controllers
{
    [AllowAnonymous]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;


        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result != 1)
                    return BadRequest(new ErrorResponse
                    {
                    Error ="Girilen E-Posta Kullanımda ve ya Şirket Hesabı bulunmakta(Davetiye linki ile panele erişim sağlayabilirsiniz.).",
                    HasError =true
                    });

                return Ok(new RegisterResponse
                {
                    HasError = false
                    });
            }
            catch (Exception exception)
            {

                return BadRequest($"User Register Error : {exception.Message}");

            }

        }

        [HttpGet("login")]
        public async Task<IActionResult> Login([FromQuery] LoginUserQuery query)
        {
            try
            {
                var codeGuid = await _mediator.Send(query);
                if (codeGuid == Guid.Empty)
                    return Unauthorized(new ErrorResponse
                    {
                        Error = "User not Found",
                        HasError = true
                    });
                return Ok(new LoginResponseModel
                {
                    HasError = false,
                    AccessGuid = codeGuid

                });

            }
            catch (Exception exception)
            {

                return BadRequest($"User Login Error : {exception.Message}");

            }

        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateUserQuery query)
        {
            try
            {
                var response = await _mediator.Send(query);
                if (response == null)
                    return BadRequest(new ErrorResponse
                    {
                        Error="Error",
                        HasError =true
                    });


                return Ok(new AuthenticateResponse
                {
                 Token= response.Token,
                 Status= response.Status
                });

            }
            catch (Exception exception)
            {

                return BadRequest($"User Login Error : {exception.Message}");

            }

        }

        //[AllowAnonymous]
        //[HttpPost("HandleInvite")]
        //public async Task<IActionResult> HandleInvite([FromBody] RegisterUserToCompanyCommand query)
        //{
        //    try
        //    {
        //        //var result = await _mediator.Send(query);
        //        //if (token == null)
        //        //    return BadRequest(new ErrorResponse
        //        //    {
        //        //        Error = "Error",
        //        //        HasError = true
        //        //    });


        //        //return Ok(new AuthenticateResponse
        //        //{
        //        //    Token = token
        //        //});

        //    }
        //    catch (Exception exception)
        //    {

        //        return BadRequest($"User Login Error : {exception.Message}");

        //    }

        //}
    }
}
