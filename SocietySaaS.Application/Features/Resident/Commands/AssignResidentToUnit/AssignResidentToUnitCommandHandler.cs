using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Resident.Commands.AssignResidentToUnit
{
    public class AssignResidentToUnitCommandHandler
        : IRequestHandler<AssignResidentToUnitCommand, bool>
    {
        private readonly IResidentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AssignResidentToUnitCommandHandler(
            IResidentRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(
            AssignResidentToUnitCommand request,
            CancellationToken cancellationToken)
        {
            var entity = new UnitResident
            {
                UnitId = request.Request.UnitId,
                ResidentId = request.Request.ResidentId,
                ResidentType = request.Request.ResidentType,
                IsPrimary = request.Request.IsPrimary,
                MoveInDate = DateTime.UtcNow
            };

            await _repository.AddUnitResidentAsync(entity, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}