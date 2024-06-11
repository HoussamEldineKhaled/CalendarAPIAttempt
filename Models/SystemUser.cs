using System;
using System.Collections.Generic;

namespace BookingMeeting.Models;

public partial class SystemUser
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? Birth { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public string? Role { get; set; }

    public int? CompanyId { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
}
