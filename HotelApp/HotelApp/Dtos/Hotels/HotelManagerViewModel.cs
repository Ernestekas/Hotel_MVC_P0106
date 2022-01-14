using HotelApp.Models.Employees;
using HotelApp.Models.Hotels;
using System.Collections.Generic;

namespace HotelApp.Dtos.Hotels
{
    public class HotelManagerViewModel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public List<Room> ReadyRooms { get; set; } = new List<Room>();
        public List<Room> RoomsNeedsCleaning { get; set; } = new List<Room>();
        public List<Room> RoomsClosedForOtherReasons { get; set; } = new List<Room>();
        public List<Room> RoomsBooked { get; set; } = new List<Room>();
        public List<Cleaner> Cleaners { get; set; } = new List<Cleaner>();
        public List<Cleaner> AvailableCleaners { get; set; } = new List<Cleaner>();
    }
}
