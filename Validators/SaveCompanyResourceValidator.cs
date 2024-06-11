using BookingMeeting.Resources;
using FluentValidation;

namespace BookingMeeting.Validators
{
    public class SaveCompanyResourceValidator : AbstractValidator<SaveCompanyResource>
    {
        public SaveCompanyResourceValidator() 
        { 
            RuleFor(n => n.CompanyName)
            .NotEmpty()
            .MaximumLength(50);
            RuleFor(d => d.CompanyDescription)
                .MinimumLength(100);
            RuleFor(E => E.CompayEmail)
                .MaximumLength(50);
            RuleFor(l => l.CompanyLogo);
            RuleFor(a => a.CompanyActive);
        }

    }
}
