using BookingMeeting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingMeeting.Core.Interfaces
{
    public interface IRoom: IRepository<Room>
    {
        Task<IEnumerable<Room>> GetAllWithRoomAsync();
        Task<Room> GetWithRoomByIdAsync(int id);
    }
}
