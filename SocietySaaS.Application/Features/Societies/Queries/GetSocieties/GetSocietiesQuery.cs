using MediatR;
using SocietySaaS.Application.Features.Societies.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Societies.Queries.GetSocieties
{
    public record GetSocietiesQuery() : IRequest<List<SocietyResponse>>;
}
