using MediatR;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Application.Commands
{
    public class ReplyLetterCommand : IRequest<int>
    {
        public int ParentLetterId { get; init; }
        public int LetterNumber { get; init; }
        public string Subject { get; init; }
        public string Body { get; init; }
        public IFormFile? Attachment { get; init; }
    }

    public class ReplyLetterHandler : IRequestHandler<ReplyLetterCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;
        private readonly IFileService _fileService;

        public ReplyLetterHandler(IUnitOfWork unitOfWork, IFileService fileService, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(ReplyLetterCommand request, CancellationToken cancellationToken)
        {
            if (_currentUserService.UserId is null)
                return 0;
            var parentLetter = await _unitOfWork.Letter.GetAsync(l => l.Id == request.ParentLetterId, cancellationToken: cancellationToken);
            if (parentLetter is null)
                return 0;
            string filePath = string.Empty;
            if (request.Attachment is { Length: > 0 })
            {
                filePath = await _fileService.SaveFileAsync(request.Attachment, cancellationToken);
            }
            var replyLetter = new Letter(
                letterNumber: request.LetterNumber,
                subject: request.Subject,
                body: request.Body,
                type: parentLetter.LetterType,
                senderId: _currentUserService.UserId.Value,
                file: filePath,
                parentId: request.ParentLetterId
            );
            replyLetter.AddRecipient(new LetterRecipient(parentLetter.SenderId, _currentUserService.UserId.Value), _currentUserService.UserId.Value, false);
            await _unitOfWork.Letter.Update(replyLetter);
            await _unitOfWork.SaveAsync(cancellationToken);
            return replyLetter.Id;
        }
    }
}