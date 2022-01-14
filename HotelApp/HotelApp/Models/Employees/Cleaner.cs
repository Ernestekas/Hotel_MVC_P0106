using HotelApp.Models.Generic;
using HotelApp.Models.Hotels;
using System.Collections.Generic;

namespace HotelApp.Models.Employees
{
    public class Cleaner : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public List<Room> RoomsAssigned { get; set; }
    }
}
