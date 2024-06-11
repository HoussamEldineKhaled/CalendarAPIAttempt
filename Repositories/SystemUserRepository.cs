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
    public class SystemUserRepository : Repository<SystemUser> , ISystemUser
    {
        public SystemUserRepository(DataBaseContext context)
    : base(context)
        { }

        public async Task<IEnumerable<SystemUser>> GetAllWithUserAsync()
        {
            return await DataBaseContext.SystemUsers.ToListAsync();

        }

        public async Task<SystemUser> GetWithUserByIdAsync(int id)
        {
            return await DataBaseContext.SystemUsers
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        private DataBaseContext DbContext
        {
            get { return Context as DataBaseContext; }
        }
    }
}
