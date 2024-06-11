using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingMeeting.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        ICompany Companies { get; }
        IMeeting Meetings { get; }
        IRoom Rooms { get; }
        ISystemUser SystemUsers { get; }
        Task<int> CommitAsync();

    }
}
