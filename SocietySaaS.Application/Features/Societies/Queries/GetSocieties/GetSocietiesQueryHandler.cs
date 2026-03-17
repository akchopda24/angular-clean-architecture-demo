using MediatR;
using SocietySaaS.Application.Common.Interfaces;
using SocietySaaS.Application.Features.Societies.DTOs;

namespace SocietySaaS.Application.Features.Societies.Queries.GetSocieties
{
    public class GetSocietiesQueryHandler
        : IRequestHandler<GetSocietiesQuery, List<SocietyResponse>>
    {
        private readonly ISocietyRepository _repository;

        public GetSocietiesQueryHandler(ISocietyRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SocietyResponse>> Handle(
            GetSocietiesQuery request,
            CancellationToken cancellationToken)
        {
            var societies = await _repository.GetAllAsync(cancellationToken);

            return societies.Select(x => new SocietyResponse
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address
            }).ToList();
        }
    }
}