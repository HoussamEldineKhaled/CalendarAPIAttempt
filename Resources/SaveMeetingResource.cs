namespace BookingMeeting.Resources
{
    public class SaveMeetingResource
    {
        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int? RelatedRoom { get; set; }

        public int? NumberOfAttendees { get; set; }

        public bool? MeetingStatus { get; set; }

        public int? MeetingManagerId { get; set; }
    }
}
