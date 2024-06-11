using BookingMeeting.Resources;
using FluentValidation;

namespace BookingMeeting.Validators
{
    public class SaveSystemUserResourceValidator : AbstractValidator<SaveSystemUserResource>
    {
        public SaveSystemUserResourceValidator() 
        { 
            RuleFor(n => n.Name).NotEmpty();
            RuleFor(b => b.Birth).NotEmpty();
            RuleFor(g =>  g.Gender).NotEmpty();
            RuleFor(e => e.Email).NotEmpty();
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(r => r.Role).NotEmpty();
            RuleFor(i => i.CompanyId).NotEmpty();
            
        
        }
    }
}
