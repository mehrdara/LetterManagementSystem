using Application.DTOs;
using Application.Interfaces;
using Mapster;
using MediatR;

namespace Application.Queries
{
    public record GetInboxQuery(
    DateTime? FromDate = null,
    DateTime? ToDate = null,
    bool? IsRead = null,
    string? SearchTerm = null
) : IRequest<List<InboxDto>>;


    public class GetInboxHandler : IRequestHandler<GetInboxQuery, List<InboxDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public GetInboxHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }


        public async Task<List<InboxDto>> Handle(GetInboxQuery request, CancellationToken cancellationToken)
        {

            var query = _unitOfWork.LetterRecipient
         .GetAll(lr => lr.RecipientId == _currentUserService.UserId)

         .Where(lr => !request.FromDate.HasValue || lr.CreatedDateTime >= request.FromDate.Value)
         .Where(lr => !request.ToDate.HasValue || lr.CreatedDateTime <= request.ToDate.Value)

         .Where(lr => !request.IsRead.HasValue || lr.IsRead == request.IsRead.Value)

         .Where(lr => string.IsNullOrWhiteSpace(request.SearchTerm) ||
                      lr.Letter.Subject.Contains(request.SearchTerm.Trim()) ||
                      lr.Letter.Body.Contains(request.SearchTerm.Trim()))

         .OrderByDescending(lr => lr.CreatedDateTime)
         .ProjectToType<InboxDto>();

            return await _unitOfWork.LetterRecipient.ToListAsync(query, cancellationToken);
        }
    }
}