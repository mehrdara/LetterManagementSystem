using Application.DTOs;
using Application.Interfaces;
using Domain.Exceptions.BaseExceptions;
using MediatR;

namespace Application.Queries
{
    public record GetLetterByIdQuery(int LetterId) : IRequest<LetterDto>;

    public class GetLetterByIdHandler : IRequestHandler<GetLetterByIdQuery, LetterDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;


        public GetLetterByIdHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;


        }

        public async Task<LetterDto> Handle(GetLetterByIdQuery request, CancellationToken cancellationToken)
        {
            var letter = await _unitOfWork.Letter.GetAsync(
                l => l.Id == request.LetterId,
                includeProperties: "Sender,Recipients",
                cancellationToken: cancellationToken
            );

            if (letter == null)
                throw new NotFoundException("Letter" + request.LetterId.ToString());

            var recipientInfo = letter.Recipients.FirstOrDefault(r => r.RecipientId == _currentUserService.UserId);
            bool isSender = letter.SenderId == _currentUserService.UserId;

            if (!isSender && recipientInfo == null)
                throw new UnauthorizedAccessException("شما اجازه مشاهده این نامه را ندارید.");

            return new LetterDto(
                letter.Id,
                letter.Subject,
                letter.Body,
                letter.Sender.UserName,
                letter.File,
                letter.CreatedDateTime,
                letter.LetterType.ToString(),
                recipientInfo?.IsRead ?? true,
                letter.ParentLetterId
            );
        }
    }
}