namespace BookingMeeting.Resources
{
    public class SaveSystemUserResource
    {
        public string Name { get; set; } = null!;

        public DateTime? Birth { get; set; }

        public string? Gender { get; set; }

        public string? Email { get; set; }

        public string Password { get; set; } = null!;

        public string? Role { get; set; }

        public int? CompanyId { get; set; }
    }
}
