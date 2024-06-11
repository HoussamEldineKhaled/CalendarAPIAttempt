using BookingMeeting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingMeeting.Services.Interfaces
{
    public interface IRoomServices
    {
        Task<IEnumerable<Room>> GetAllWithRoom();
        Task<Room> GetRoomById(int id);
        Task<Room> CreateRoom(Room newRoom);
        Task UpdateRoom(Room roomToBeUpdated, Room room);
        Task DeleteRoom(Room room);
    }
}
