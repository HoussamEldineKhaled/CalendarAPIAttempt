namespace BookingMeeting.Resources
{
    public class RoomResource
    {
        public int RoomId { get; set; }

        public string? RoomLocation { get; set; }

        public int? RoomCapacity { get; set; }

        public string? RoomDescription { get; set; }

        public int? RelatedCompany { get; set; }
    }
}
