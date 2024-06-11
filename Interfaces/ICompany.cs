using BookingMeeting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingMeeting.Core.Interfaces
{
    public interface ICompany : IRepository<Company>
    {
        Task<IEnumerable<Company>> GetAllWithCompanyAsync();
        Task<Company> GetWithCompanyByIdAsync(int id);
    }
}
