using Application.Commands;
using Application.Interfaces;
using FluentValidation;
namespace Application.Validators
{
    public class ForwardLetterCommandValidator : AbstractValidator<ForwardLetterCommand>
    {
        public ForwardLetterCommandValidator(IUnitOfWork unitOfWork)
        {

            RuleFor(x => x.LetterId)
                .NotEmpty().WithMessage("شناسه نامه الزامی است.")
                .GreaterThan(0).WithMessage("شناسه نامه معتبر نیست.");
            RuleFor(x => x.RecipientIds)
                .NotEmpty().WithMessage("حداقل یک دریافت‌کننده باید انتخاب شود.")
                .Must(list => list != null && list.Count > 0).WithMessage("لیست دریافت‌کنندگان نمی‌تواند خالی باشد.")
                .ForEach(id =>
                {
                    id.GreaterThan(0).WithMessage(" دریافت‌کننده معتبر نیست.");
                });
            RuleFor(x => x.RecipientIds)
                .Must(list => list.Count <= 50).WithMessage("نمی‌توانید به بیش از ۵۰ نفر همزمان فوروارد کنید.");
        }
    }
}