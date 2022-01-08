using HotelApp.Data;
using HotelApp.Models.Location;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HotelApp.Repositories.Locations
{
    public class CountriesRepository : RepositoryBase<Country>
    {
        public CountriesRepository(DataContext context) : base(context) { }

        public List<Country> GetAllIncluded()
        {
            return _context.Countries.Include(c => c.Cities).ToList();
        }
    }
}
