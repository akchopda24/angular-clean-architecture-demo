using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocietySaaS.API.Attributes;
using SocietySaaS.Application.Common.Permissions;
using SocietySaaS.Application.Features.Societies.Commands.CreateSociety;
using SocietySaaS.Application.Features.Societies.Commands.UpdateSociety;
using SocietySaaS.Application.Features.Societies.DTOs;
using SocietySaaS.Application.Features.Societies.Queries.GetSocieties;
using SocietySaaS.Domain.Entities;
using SocietySaaS.Infrastructure.Persistence;

namespace SocietySaaS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocietiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocietiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [AuthorizePermission(Permissions.Society.Create)]
        public async Task<ActionResult<SocietyResponse>> Create(
            [FromBody] CreateSocietyRequest request)
        {
            var result = await _mediator.Send(
                new CreateSocietyCommand(request));

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<SocietyResponse>>> Get()
        {
            var result = await _mediator.Send(
                new GetSocietiesQuery());

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateSocietyRequest request)
        {
            var result = await _mediator.Send(new UpdateSocietyCommand(id, request));

            return Ok(result);
        }
    }
}
