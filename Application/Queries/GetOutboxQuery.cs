using MediatR;
using Application.Interfaces;
using Application.DTOs;
using Mapster;
namespace Application.Queries
{
    public record GetOutboxQuery(
    DateTime? FromDate = null,
    DateTime? ToDate = null,
    string? SearchTerm = null) : IRequest<List<OutboxDto>>;

    public class GetOutboxHandler : IRequestHandler<GetOutboxQuery, List<OutboxDto>>
    {
        private readonly ICurrentUserService _currentUserService;

        private readonly IUnitOfWork _unitOfWork;
        public GetOutboxHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _unitOfWork = unitOfWork;

        }
        public async Task<List<OutboxDto>> Handle(GetOutboxQuery request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.Letter
                    .GetAll(l => l.SenderId == _currentUserService.UserId ||
                                 l.Recipients.Any(r => r.ForwardedByUserId == _currentUserService.UserId))
                    .Where(l => !request.FromDate.HasValue || l.CreatedDateTime >= request.FromDate)
                    .Where(l => !request.ToDate.HasValue || l.CreatedDateTime <= request.ToDate)
                    .Where(l => string.IsNullOrWhiteSpace(request.SearchTerm) ||
                                l.Subject.Contains(request.SearchTerm) || l.Body.Contains(request.SearchTerm))
                    .OrderByDescending(l => l.CreatedDateTime)
                    .ProjectToType<OutboxDto>();

            return await _unitOfWork.Letter.ToListAsync(query, cancellationToken);

        }
    }
}


