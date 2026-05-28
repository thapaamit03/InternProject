using InterProject.Application.Features.Auth.Commands;
using InterProject.Application.Features.Auth.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InternProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto request)
        {
            var response = await _mediator.Send(new RegisterUser(request));

            return Ok(new
            {
                success = true,
                message = response.Message,
                email=response.Email
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto request)
        {
            var response = await _mediator.Send(new LoginUser(request));

            return Ok(new
            {
                success = true,
                message = "user loggedin successfully",
               accessToken=response.AccessToken,
                refreshToken=response.RefreshToken
                
            });
        }

    }
}
