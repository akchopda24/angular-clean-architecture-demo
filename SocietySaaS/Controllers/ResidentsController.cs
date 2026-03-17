using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocietySaaS.Application.Features.Resident.Commands.AssignResidentToUnit;
using SocietySaaS.Application.Features.Resident.Commands.CreateResident;
using SocietySaaS.Application.Features.Resident.DTOs;
using SocietySaaS.Application.Features.Resident.Queries;

namespace SocietySaaS.API.Controllers
{
    [ApiController]
    [Route("api/residents")]
    public class ResidentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResidentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ResidentResponse>> Create(
            CreateResidentRequest request)
        {
            var result = await _mediator.Send(
                new CreateResidentCommand(request));

            return Ok(result);
        }

        [HttpPost("assign")]
        public async Task<ActionResult> AssignToUnit(
            AssignResidentToUnitRequest request)
        {
            await _mediator.Send(
                new AssignResidentToUnitCommand(request));

            return Ok();
        }

        [HttpGet("unit/{unitId}")]
        public async Task<ActionResult<List<ResidentResponse>>> GetByUnit(
            Guid unitId)
        {
            var result = await _mediator.Send(
                new GetResidentsByUnitQuery(unitId));

            return Ok(result);
        }
    }
}