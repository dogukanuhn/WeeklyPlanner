using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;

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



        /// <summary>
        /// Register to Weekly Planner
        /// </summary>
        /// <response code="200">Account created successfully</response>
        /// <response code="400">Error while creating account</response>          
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegisterResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result != 1)
                    return BadRequest(new BaseResponse
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

        /// <summary>
        /// Login with email
        /// </summary>
        /// <response code="200">Return accessguid for authentication</response>
        /// <response code="400">User not found or error</response>          
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
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



        /// <summary>
        /// Login access code which came from Login request
        /// </summary>
        /// <response code="200">Get JWT token</response>
        /// <response code="400">Authentication error</response>          
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthenticateResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
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
