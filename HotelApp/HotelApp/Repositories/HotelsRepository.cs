using HotelApp.Data;
using HotelApp.Models;
using HotelApp.Models.Hotels;
using HotelApp.Models.Location;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Repositories
{
    public class HotelsRepository : RepositoryBase<Hotel>
    {
        public HotelsRepository(DataContext context) : base(context) { }

        public Hotel GetByIdIncludeFloors(int hotelId)
        {
            return _context.Hotels.Include(h => h.Floors).ThenInclude(f => f.Rooms).ThenInclude(r => r.Cleaner).Where(h => h.Id == hotelId).FirstOrDefault();
        }

        public Hotel GetHotelWithEmployess(int hotelId)
        {
            return _context.Hotels.Include(x => x.Cleaners).FirstOrDefault(h => h.Id == hotelId);
        }

        public City GetHotelLocation(int hotelId)
        {
            Hotel hotel = _context.Hotels.Include(h => h.City).ThenInclude(ci => ci.Country).FirstOrDefault(h => h.Id == hotelId);
            City result = hotel.City;

            return result;
        }

        public List<Room> GetHotelRooms(int hotelId)
        {
            return GetByIdIncludeFloors(hotelId).Floors.SelectMany(f => f.Rooms).ToList();
        }

        public List<Hotel> GetAllWithLocations()
        {
            return _context.Hotels.Include(x => x.City).ThenInclude(x => x.Country).ToList();
        }
    }
}
