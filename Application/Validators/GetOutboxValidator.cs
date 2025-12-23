using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Queries;
using FluentValidation;

namespace Application.Validators
{
    public class GetOutboxValidator : AbstractValidator<GetOutboxQuery>
    {
        public GetOutboxValidator()
        {
            RuleFor(x => x.FromDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("تاریخ شروع نمی‌تواند در آینده باشد.");

            RuleFor(x => x.ToDate)
                .GreaterThanOrEqualTo(x => x.FromDate)
                .When(x => x.FromDate.HasValue && x.ToDate.HasValue)
                .WithMessage("تاریخ پایان باید بعد از تاریخ شروع باشد.");

            RuleFor(x => x.SearchTerm)
                .MaximumLength(100).WithMessage("عبارت جستجو نباید بیش از ۱۰۰ کاراکتر باشد.")
                .MinimumLength(3).When(x => !string.IsNullOrEmpty(x.SearchTerm))
                .WithMessage("برای جستجو حداقل ۳ کاراکتر بنویسید.");
        }
    }
}