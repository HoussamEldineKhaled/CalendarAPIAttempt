using BookingMeeting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingMeeting.Services.Interfaces
{
    public interface ISystemUserServices
    {
        Task<IEnumerable<SystemUser>> GetAllWithUser();
        Task<SystemUser> GetUserById(int id);
        Task<SystemUser> CreateUser(SystemUser newUser);
        Task UpdateUser(SystemUser userToBeUpdated, SystemUser user);
        Task DeleteUser(SystemUser user);
    }
}
