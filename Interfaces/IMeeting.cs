using BookingMeeting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingMeeting.Core.Interfaces
{
    public interface IMeeting : IRepository<Meeting>
    {
        Task<IEnumerable<Meeting>> GetAllWithMeetingAsync();
        Task<Meeting> GetWithMeetingByIdAsync(int id);
    }
}
