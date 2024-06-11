﻿using BookingMeeting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingMeeting.Core.Interfaces
{
    public interface ISystemUser : IRepository<SystemUser>
    {
        Task<IEnumerable<SystemUser>> GetAllWithUserAsync();
        Task<SystemUser> GetWithUserByIdAsync(int id);
    }
}
