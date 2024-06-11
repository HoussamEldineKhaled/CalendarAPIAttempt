using BookingMeeting.Core.Interfaces;
using BookingMeeting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingMeeting.Core.Repositories
{
    public class MeetingRepository : Repository<Meeting> , IMeeting
    {
        public MeetingRepository(DataBaseContext context)
    : base(context)
        { }

        public async Task<IEnumerable<Meeting>> GetAllWithMeetingAsync()
        {
            return await DataBaseContext.Meetings.ToListAsync();

        }

        public async Task<Meeting> GetWithMeetingByIdAsync(int id)
        {
            return await DataBaseContext.Meetings
                .SingleOrDefaultAsync(m => m.ReservationId == id);
        }

        private DataBaseContext DbContext
        {
            get { return Context as DataBaseContext; }
        }
    }
}
