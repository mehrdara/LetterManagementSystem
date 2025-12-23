

namespace Application.DTOs
{
    public record LetterDto(
            int Id,
            string Subject,
            string Body,
            string SenderName,
            string? AttachmentPath,
            DateTime CreatedAt,
            string LetterType,
            bool IsRead,
            int? ParentLetterId
        );
}