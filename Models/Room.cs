using System;
using System.Collections.Generic;

namespace BookingMeeting.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string? RoomLocation { get; set; }

    public int? RoomCapacity { get; set; }

    public string? RoomDescription { get; set; }

    public int? RelatedCompany { get; set; }

    public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();

    public virtual Company? RelatedCompanyNavigation { get; set; }
}
