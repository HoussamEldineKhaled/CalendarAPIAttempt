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
    public class CompanyRepository : Repository<Company> , ICompany
    {
        public CompanyRepository(DataBaseContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Company>> GetAllWithCompanyAsync()
        {
            return await DataBaseContext.Companies.ToListAsync();
                
        }

        public async Task<Company> GetWithCompanyByIdAsync(int id)
        {
            return await DataBaseContext.Companies
                .SingleOrDefaultAsync(m => m.CompanyId == id); 
        }

        private DataBaseContext DbContext
        {
            get { return Context as DataBaseContext; }
        }
    }
}
