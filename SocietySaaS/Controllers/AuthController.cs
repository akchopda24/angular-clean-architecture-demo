using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocietySaaS.Application.Features.Auth.Commands.Login;
using SocietySaaS.Application.Features.Auth.DTOs;

namespace SocietySaaS.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(
            LoginRequest request)
        {
            var result = await _mediator.Send(
                new LoginCommand(request));

            return Ok(result);
        }
    }
}