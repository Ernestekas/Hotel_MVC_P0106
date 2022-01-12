using HotelApp.Data;
using HotelApp.Models.Hotels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Repositories.Hotels
{
    public class FloorsRepository : RepositoryBase<Floor>
    {
        public FloorsRepository(DataContext context) : base(context) { }

        public List<Floor> GetAllByHotelId(int hotelId)
        {
            return _context.Floors.Where(f => f.HotelId == hotelId).ToList();
        }
    }
}
