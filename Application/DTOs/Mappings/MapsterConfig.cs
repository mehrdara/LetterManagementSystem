using Mapster;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings
{
    public class MapsterConfig
    {
        public static void RegisterMappings()
        {
            //Inbox
            TypeAdapterConfig<LetterRecipient, InboxDto>.NewConfig()
                .Map(dest => dest.LetterId, src => src.LetterId)
                .Map(dest => dest.Subject, src => src.Letter.Subject)
                .Map(dest => dest.OriginalSenderName, src => src.Letter.Sender.UserName)
                .Map(dest => dest.ForwardedBy, src =>
                    src.ForwardedByUserId.HasValue
                    ? src.ForwarderUser.UserName
                    : "direct send")
                .Map(dest => dest.IsForwarded, src => src.ForwardedByUserId.HasValue)
                .Map(dest => dest.IsRead, src => src.IsRead)
                .Map(dest => dest.ReceivedDateTime, src => src.CreatedDateTime)
                .Map(dest => dest.LetterType, src => src.Letter.LetterType.ToString());

            TypeAdapterConfig<Letter, OutboxDto>.NewConfig()
                .Map(dest => dest.LetterId, src => src.Id)
                .Map(dest => dest.Subject, src => src.Subject)
                .Map(dest => dest.SentAt, src => src.CreatedDateTime)
                .Map(dest => dest.LetterType, src => src.LetterType.ToString())
                .Map(dest => dest.Recipients, src => src.Recipients.Select(r => r.Recipient.UserName))
                .Map(dest => dest.ReadCount, src => src.Recipients.Count(r => r.IsRead))
                .Map(dest => dest.TotalRecipients, src => src.Recipients.Count());
        }
    }
}