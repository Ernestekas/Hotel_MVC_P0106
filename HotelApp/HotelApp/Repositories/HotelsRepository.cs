using HotelApp.Data;
using HotelApp.Models;
using HotelApp.Models.Hotels;
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

        public Hotel GetByIdIncludeFloors(int id)
        {
            return _context.Hotels.Include(h => h.Floors).ThenInclude(f => f.Rooms).Where(h => h.Id == id).FirstOrDefault();
        }
    }
}
