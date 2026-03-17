using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocietySaaS.Application.Features.Users.Commands.CreateUser;
using SocietySaaS.Application.Features.Users.Commands.UpdateUser;
using SocietySaaS.Application.Features.Users.Commands.DeleteUser;
using SocietySaaS.Application.Features.Users.Commands.ChangePassword;
using SocietySaaS.Application.Features.Users.Commands.ActivateUser;
using SocietySaaS.Application.Features.Users.Commands.DeactivateUser;
using SocietySaaS.Application.Features.Users.Queries.GetUsers;
using SocietySaaS.Application.Features.Users.Queries.GetUserById;
using SocietySaaS.Application.Features.Users.Commands.ResetUserPassword;

namespace SocietySaaS.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
            => Ok(await _mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return Ok();
        }

        [HttpPost("{id}/activate")]
        public async Task<IActionResult> Activate(Guid id)
        {
            await _mediator.Send(new ActivateUserCommand(id));
            return Ok();
        }

        [HttpPost("{id}/deactivate")]
        public async Task<IActionResult> Deactivate(Guid id)
        {
            await _mediator.Send(new DeactivateUserCommand(id));
            return Ok();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
            => Ok(await _mediator.Send(new GetUsersQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
            => Ok(await _mediator.Send(new GetUserByIdQuery(id)));
    }
}