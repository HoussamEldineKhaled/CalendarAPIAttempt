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
    public class RoomRepository : Repository<Room> , IRoom
    {
        public RoomRepository(DataBaseContext context)
    : base(context)
        { }

        public async Task<IEnumerable<Room>> GetAllWithRoomAsync()
        {
            return await DataBaseContext.Rooms.ToListAsync();

        }

        public async Task<Room> GetWithRoomByIdAsync(int id)
        {
            return await DataBaseContext.Rooms
                .SingleOrDefaultAsync(m => m.RoomId == id);
        }

        private DataBaseContext DbContext
        {
            get { return Context as DataBaseContext; }
        }
    }
}
