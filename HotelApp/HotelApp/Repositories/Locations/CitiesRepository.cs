using HotelApp.Data;
using HotelApp.Models.Location;

namespace HotelApp.Repositories.Locations
{
    public class CitiesRepository : RepositoryBase<City>
    {
        public CitiesRepository(DataContext context) : base(context) { }
    }
}
