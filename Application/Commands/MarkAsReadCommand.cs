using MediatR;
using Application.Interfaces;
using Domain.Exceptions;
using Domain.Exceptions.BaseExceptions;

namespace Application.Commands
{
    public record MarkAsReadCommand(int LetterId) : IRequest<Unit>;

    public class MarkLetterAsReadHandler : IRequestHandler<MarkAsReadCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;
        public MarkLetterAsReadHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }
        public async Task<Unit> Handle(MarkAsReadCommand request, CancellationToken cancellationToken)
        {
            var letter = await _unitOfWork.Letter.GetAsync(
              l => l.Id == request.LetterId,
              includeProperties: "Recipients"
          );
            if (letter == null)
            {
                throw new NotFoundException("نامه مورد نظر یافت نشد.");
            }
            var currentUserId = _currentUserService.UserId;
            var isRecipient = letter.Recipients.Any(r => r.RecipientId == currentUserId);

            if (!isRecipient)
            {
                throw new BadRequestException("شما گیرنده این نامه نیستید و نمی‌توانید آن را خوانده شده علامت بزنید.");
            }

            letter.MarkAsReadByRecipient(currentUserId.Value);
            _unitOfWork.Letter.Update(letter);
            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}