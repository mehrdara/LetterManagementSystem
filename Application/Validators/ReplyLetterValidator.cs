using Domain.EntityPropertyConfigurations;
using Application.Commands;
using FluentValidation;
namespace Application.Validators
{

    public class ReplyLetterValidator : AbstractValidator<ReplyLetterCommand>
    {
        public ReplyLetterValidator()
        {
            RuleFor(x => x.ParentLetterId)
                .NotEmpty().WithMessage("شناسه نامه اصلی الزامی است.")
                .GreaterThan(0).WithMessage("شناسه نامه اصلی معتبر نیست.");

            RuleFor(x => x.LetterNumber)
                .NotEmpty().WithMessage("شماره نامه الزامی است.")
                .GreaterThan(0).WithMessage("شماره نامه باید مثبت باشد.");

            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("موضوع پاسخ الزامی است.");
            RuleFor(x => x.Body)
                .NotEmpty().WithMessage("متن پاسخ نمی‌تواند خالی باشد.");

        }
    }
}