using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Application.Features.Resident.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Features.Resident.Commands.CreateResident
{
    public class CreateResidentCommandHandler
        : IRequestHandler<CreateResidentCommand, ResidentResponse>
    {
        private readonly IResidentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateResidentCommandHandler(
            IResidentRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResidentResponse> Handle(
            CreateResidentCommand request,
            CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Resident
            {
                FirstName = request.Request.FirstName,
                LastName = request.Request.LastName,
                Mobile = request.Request.Mobile,
                Email = request.Request.Email
            };

            await _repository.AddAsync(entity, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ResidentResponse
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Mobile = entity.Mobile,
                Email = entity.Email
            };
        }
    }
}