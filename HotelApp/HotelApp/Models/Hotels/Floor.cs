using HotelApp.Models.Generic;
using System.Collections.Generic;

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
