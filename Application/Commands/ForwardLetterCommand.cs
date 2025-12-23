using MediatR;
using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Exceptions.BaseExceptions;

namespace Application.Commands
{
    public record ForwardLetterCommand(int LetterId, List<int> RecipientIds) : IRequest<int>

    ;
    public class ForwardLetterHandler : IRequestHandler<ForwardLetterCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public ForwardLetterHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(ForwardLetterCommand request, CancellationToken cancellationToken)
        {
            var letter = await _unitOfWork.Letter.GetAsync(l => l.Id == request.LetterId, includeProperties: "Recipients", cancellationToken: cancellationToken) ?? throw new NotFoundException("Letter not found");
            foreach (var recipientId in request.RecipientIds)
            {
                letter.AddRecipient(new LetterRecipient(recipientId, _currentUserService.UserId.Value), _currentUserService.UserId.Value, true);
            }
            _unitOfWork.Letter.Update(letter);
            await _unitOfWork.SaveAsync(cancellationToken);

            return letter.Id;

        }
    }
}