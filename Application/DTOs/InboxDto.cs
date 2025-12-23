using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record InboxDto(
            int LetterId,
            string Subject,
            string OriginalSenderName,
            string ForwardedBy,
            bool IsForwarded,
            bool IsRead,
            DateTime ReceivedDateTime,
            string LetterType
        );
}