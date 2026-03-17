using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Application.Features.Resident.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Resident.Queries
{
    public class GetResidentsByUnitQueryHandler
        : IRequestHandler<GetResidentsByUnitQuery, List<ResidentResponse>>
    {
        private readonly IResidentRepository _repository;

        public GetResidentsByUnitQueryHandler(
            IResidentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ResidentResponse>> Handle(
            GetResidentsByUnitQuery request,
            CancellationToken cancellationToken)
        {
            var residents = await _repository
                .GetResidentsByUnitAsync(request.UnitId, cancellationToken);

            return residents.Select(x => new ResidentResponse
            {
                Id = x.Resident.Id,
                FirstName = x.Resident.FirstName,
                LastName = x.Resident.LastName,
                Mobile = x.Resident.Mobile,
                Email = x.Resident.Email
            }).ToList();
        }
    }
}