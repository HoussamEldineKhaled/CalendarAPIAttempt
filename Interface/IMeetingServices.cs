using BookingMeeting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingMeeting.Services.Interfaces
{
    public interface IMeetingServices
    {
        Task<IEnumerable<Meeting>> GetAllWithMeeting();
        Task<Meeting> GetMeetingById(int id);
        Task<Meeting> CreateMeeting(Meeting newMeeting);
        Task UpdateMeeting(Meeting meetingToBeUpdated, Meeting meeting);
        Task DeleteMeeting(Meeting meeting);
    }
}
