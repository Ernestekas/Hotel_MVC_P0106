using HotelApp.Data;
using HotelApp.Models.Hotels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotelApp.Repositories.Hotels
{
    public class RoomsRepository : RepositoryBase<Room>
    {
        public RoomsRepository(DataContext context) : base(context) { }

        public int GetHotelByRoomId(int roomId)
        {
            return _context.Rooms.Include(r => r.Floor).FirstOrDefault(r => r.Id == roomId).Floor.HotelId;
        }

        public Room GetByIdIncludeCustomer(int roomId)
        {
            return _context.Rooms.Include(r => r.Customer).FirstOrDefault(r => r.Id == roomId);
        }
    }
}
