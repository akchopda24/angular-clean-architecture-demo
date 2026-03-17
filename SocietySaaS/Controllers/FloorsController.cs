using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocietySaaS.Application.Features.Floors.Commands.CreateFloor;
using SocietySaaS.Application.Features.Floors.Commands.DeleteFloor;
using SocietySaaS.Application.Features.Floors.Commands.UpdateFloor;
using SocietySaaS.Application.Features.Floors.DTOs;
using SocietySaaS.Application.Features.Floors.Queries;

namespace SocietySaaS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FloorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FloorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFloorDto dto)
        {
            var id = await _mediator.Send(new CreateFloorCommand(dto));
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFloorDto dto)
        {
            await _mediator.Send(new UpdateFloorCommand(dto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteFloorCommand(id));
            return NoContent();
        }

        [HttpGet("building/{buildingId}")]
        public async Task<IActionResult> GetByBuilding(Guid buildingId)
        {
            var result = await _mediator.Send(new GetFloorsByBuildingQuery(buildingId));
            return Ok(result);
        }
    }
}