using HotelApp.Data;
using HotelApp.Models.Hotels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
