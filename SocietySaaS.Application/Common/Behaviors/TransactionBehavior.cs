using MediatR;
using SocietySaaS.Application.Common.Interfaces;

namespace SocietySaaS.Application.Common.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            // Skip Queries
            if (request.GetType().Name.EndsWith("Query"))
            {
                return await next();
            }

            var response = await next();

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}