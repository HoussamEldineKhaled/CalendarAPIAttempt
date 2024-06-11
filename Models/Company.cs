using System;
using System.Collections.Generic;

namespace BookingMeeting.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? CompanyDescription { get; set; }

    public string? CompayEmail { get; set; }

    public byte[]? CompanyLogo { get; set; }

    public bool? CompanyActive { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<SystemUser> SystemUsers { get; set; } = new List<SystemUser>();
}
