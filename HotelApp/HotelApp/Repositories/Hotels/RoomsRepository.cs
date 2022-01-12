using HotelApp.Data;
using HotelApp.Models.Hotels;
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
    }
}
