using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record OutboxDto(
            int LetterId,
            string Subject,
            DateTime SentAt,
            string LetterType,
            List<string> Recipients,
            int ReadCount,
            int TotalRecipients
        );
}