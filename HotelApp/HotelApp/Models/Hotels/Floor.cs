using HotelApp.Models.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Models.Hotels
{
    public class Floor : Entity
    {
        public int BuildingFloor { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
