namespace BookingMeeting.Resources
{
    public class MeetingResource
    {
        public int ReservationId { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int? RelatedRoom { get; set; }

        public int? NumberOfAttendees { get; set; }

        public bool? MeetingStatus { get; set; }
        public SystemUserResources MeetingManager { get; set; }
        public RoomResource RelatedRoomNavigation { get; set; }
    }
}
