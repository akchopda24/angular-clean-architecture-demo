using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocietySaaS.Application.Features.Buildings.Commands.CreateBuilding;
using SocietySaaS.Application.Features.Buildings.DTOs;
using SocietySaaS.Application.Features.Buildings.Queries.GetBuildings;

namespace SocietySaaS.API.Controllers
{
    [ApiController]
    [Route("api/buildings")]
    public class BuildingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BuildingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<BuildingResponse>> Create(
            CreateBuildingRequest request)
        {
            var result = await _mediator.Send(
                new CreateBuildingCommand(request));

            return Ok(result);
        }

        [HttpGet("{societyId}")]
        public async Task<ActionResult<List<BuildingResponse>>> Get(
            Guid societyId)
        {
            var result = await _mediator.Send(
                new GetBuildingsQuery(societyId));

            return Ok(result);
        }
    }
}