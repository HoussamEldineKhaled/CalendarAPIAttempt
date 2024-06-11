namespace BookingMeeting.Resources
{
    public class CompanyResource
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; } = null!;

        public string? CompanyDescription { get; set; }

        public string? CompayEmail { get; set; }

        public byte[]? CompanyLogo { get; set; }

        public bool? CompanyActive { get; set; }


    }
}
