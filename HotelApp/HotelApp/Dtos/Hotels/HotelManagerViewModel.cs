using HotelApp.Models.Employees;
using HotelApp.Models.Hotels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Cleaner> Cleaners { get; set; } = new List<Cleaner>();
    }
}
