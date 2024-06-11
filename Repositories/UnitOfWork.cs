using BookingMeeting.Core.Interfaces;
using BookingMeeting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingMeeting.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;
        private ICompany _company;
        private IMeeting _meeting;
        private IRoom _room;
        private ISystemUser _systemUser;

        public UnitOfWork(DataBaseContext context)
        {
            this._context = context;
        }

        public ICompany Companies => _company = _company ?? new CompanyRepository(_context);

        public IMeeting Meetings => _meeting = _meeting ?? new MeetingRepository(_context);
        public IRoom Rooms => _room = _room ?? new RoomRepository(_context);
        public ISystemUser SystemUsers => _systemUser = _systemUser ?? new SystemUserRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
