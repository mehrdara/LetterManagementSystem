using Application.Commands;
using FluentValidation;
using Domain.EntityPropertyConfigurations;
namespace Application.Validators
{
    public class SendLetterValidator : AbstractValidator<SendLetterCommand>
    {
        public SendLetterValidator()
        {

            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("موضوع نامه الزامی است.")
                .MinimumLength(LetterPropertyConfiguration.SubjectMinLength).WithMessage("موضوع کوتاه است.")
                .MaximumLength(LetterPropertyConfiguration.SubjectMaxLength).WithMessage("متن موضوع بلند است ");

            RuleFor(x => x.Body)
                .NotEmpty().WithMessage("متن نامه نمی‌تواند خالی باشد.")
                .MinimumLength(LetterPropertyConfiguration.BodyMinLength).WithMessage("متن نامه خیلی کوتاه است.");

            RuleFor(x => x.LetterNumber)
                .GreaterThan(0).WithMessage("شماره نامه باید معتبر باشد.");
            RuleFor(x => x.RecipientIds)
                .NotEmpty().WithMessage("حداقل یک گیرنده باید انتخاب شود.")
                .Must(ids => ids != null && ids.Distinct().Count() == ids.Count)
                .WithMessage("لیست گیرندگان حاوی شناسه‌های تکراری است.");
            RuleFor(x => x.LetterType)
                .IsInEnum().WithMessage("نوع نامه انتخاب شده معتبر نیست.");
        }
    }
}

