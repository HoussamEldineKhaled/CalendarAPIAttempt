using BookingMeeting.Resources;
using FluentValidation;

namespace BookingMeeting.Validators
{
    public class SaveRoomResourceValidator : AbstractValidator<SaveRoomResource>
    {
        public SaveRoomResourceValidator() 
        {
            RuleFor(l => l.RoomLocation).NotEmpty();
            RuleFor(c => c.RoomCapacity).NotEmpty().WithMessage("Capacity greater than 0");
            RuleFor(d => d.RoomDescription);
            RuleFor(r => r.RelatedCompany).NotEmpty();
        
        }

    }
}
