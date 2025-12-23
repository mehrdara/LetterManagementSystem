using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Validators
{
    using Application.Queries;
    using FluentValidation;

    public class GetInboxValidator : AbstractValidator<GetInboxQuery>
    {
        public GetInboxValidator()
        {
            RuleFor(x => x.FromDate)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("تاریخ شروع نمی‌تواند در آینده باشد.");

            RuleFor(x => x.ToDate)
                .GreaterThanOrEqualTo(x => x.FromDate)
                .When(x => x.FromDate.HasValue && x.ToDate.HasValue)
                .WithMessage("تاریخ پایان نباید قبل از تاریخ شروع باشد.");

            RuleFor(x => x.SearchTerm)
                .MaximumLength(100).WithMessage("عبارت جستجو نباید بیشتر از ۱۰۰ کاراکتر باشد.")
                .MinimumLength(3).When(x => !string.IsNullOrWhiteSpace(x.SearchTerm))
                .WithMessage("برای جستجو حداقل ۳ کاراکتر وارد کنید.");

        }
    }
}