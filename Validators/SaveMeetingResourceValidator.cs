using BookingMeeting.Resources;
using FluentValidation;

namespace BookingMeeting.Validators
{
    public class SaveMeetingResourceValidator : AbstractValidator<SaveMeetingResource>
    {
        public SaveMeetingResourceValidator() 
        { 
            RuleFor(s => s.StartTime).NotEmpty();
            RuleFor(e => e.EndTime).NotEmpty();
            RuleFor(r => r.RelatedRoom).NotEmpty();
            RuleFor(n => n.NumberOfAttendees).NotEmpty()
                .WithMessage("Number of attendees greater than 0");
            RuleFor(m => m.MeetingStatus).NotEmpty();
            RuleFor(i => i.MeetingManagerId).NotEmpty();

        
        
        }

    }
}
