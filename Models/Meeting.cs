using System;
using System.Collections.Generic;

namespace BookingMeeting.Models;

public partial class Meeting
{
    public int ReservationId { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? RelatedRoom { get; set; }

    public int? NumberOfAttendees { get; set; }

    public bool? MeetingStatus { get; set; }

    public int? MeetingManagerId { get; set; }

    public virtual SystemUser? MeetingManager { get; set; }

    public virtual Room? RelatedRoomNavigation { get; set; }
}
