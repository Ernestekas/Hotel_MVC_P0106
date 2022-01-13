using HotelApp.Data;
using HotelApp.Models.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Repositories.Employees
{
    public class EmployeesRepository : RepositoryBase<Cleaner>
    {
        public EmployeesRepository(DataContext context) : base(context) { }

        public List<Cleaner> GetAllIncluedeHotel()
        {
            return _context.Cleaners
                    .Include(c => c.Hotel)
                    .ThenInclude(h => h.City)
                    .ThenInclude(ci => ci.Country)
                    .ToList();
        }

        public List<Cleaner> GetCleanersByHotel(int hotelId)
        {
            return _context.Cleaners.Where(c => c.HotelId == hotelId).ToList();
        }
    }
}
