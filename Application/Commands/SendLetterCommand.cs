using MediatR;
using Microsoft.AspNetCore.Http;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions.BaseExceptions;

namespace Application.Commands
{

    public record SendLetterCommand(
        long LetterNumber,
        string Subject,
        string Body,
        IFormFile? Attachment,
        LetterType LetterType,
        List<int> RecipientIds


    ) : IRequest<int>;

    public class SendLetterHandler : IRequestHandler<SendLetterCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        private readonly ICurrentUserService _currentUserService;
        public SendLetterHandler(IUnitOfWork unitOfWork, IFileService fileService, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
            _currentUserService = currentUserService;
        }
        public async Task<int> Handle(SendLetterCommand request, CancellationToken cancellationToken)
        {
            if (_currentUserService.UserId is null)
                return 0;
            var sender = await _unitOfWork.User.GetAsync(u => u.Id == _currentUserService.UserId, cancellationToken: cancellationToken);
            if (sender is null)
                throw new NotFoundException("sender not found");

            string filePath = string.Empty;
            if (request.Attachment is { Length: > 0 })
            {
                filePath = await _fileService.SaveFileAsync(request.Attachment, cancellationToken);
            }
            var letter = new Letter(
                request.LetterNumber,
                request.Subject,
                request.Body,
                _currentUserService.UserId.Value,
                filePath,
                request.LetterType
            );
            if (request.RecipientIds is not null)
            {
                foreach (var recipientId in request.RecipientIds)
                {
                    var recipientRelation = new LetterRecipient(recipientId, null);
                    letter.AddRecipient(recipientRelation, _currentUserService.UserId.Value, false);
                }
            }
            await _unitOfWork.Letter.AddAsync(letter, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            return letter.Id;
        }
    }

}

