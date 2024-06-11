using BookingMeeting.Models;

namespace BookingMeeting.Resources
{
    public class SystemUserResources
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime? Birth { get; set; }

        public string? Gender { get; set; }

        public string? Email { get; set; }

        public string Password { get; set; } = null!;

        public string? Role { get; set; }
        public Company Company { get; set; }
    }
}
