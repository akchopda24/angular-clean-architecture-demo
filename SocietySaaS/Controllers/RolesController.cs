using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocietySaaS.Application.Features.Roles.Commands.CreateRole;
using SocietySaaS.Application.Features.Roles.Commands.DeleteRole;
using SocietySaaS.Application.Features.Roles.Commands.UpdateRole;
using SocietySaaS.Application.Features.Roles.Queries.GetRoles;

namespace SocietySaaS.API.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleCommand command)
            => Ok(await _mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> Update(UpdateRoleCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteRoleCommand(id));
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
            => Ok(await _mediator.Send(new GetRolesQuery()));
    }
}